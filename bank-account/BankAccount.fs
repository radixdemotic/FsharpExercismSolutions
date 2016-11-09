
module Exercism.BankAccount

open System

type AccountMessage =
    | UpdateBalance of float
    | GetBalance of AsyncReplyChannel<Option<float>>
    | Open
    | Close
type Agent<'T> = MailboxProcessor<'T>

type BankAccount() = 
    let account = new Agent<AccountMessage>(fun agent ->
        let rec loop balance =
            async {
                let! msg = agent.Receive()

                let next = 
                    match msg with
                    | Open ->
                        match balance with
                        | None -> (Some 0.0)
                        | b -> 
                            printfn "Error: tried to open an already open account."
                            b
                        |> loop
                    | Close -> loop None
                    | GetBalance c -> 
                        c.Reply balance
                        loop balance
                    | UpdateBalance b ->
                        match balance with
                        | None ->
                            printfn "Error: tried to update balance of a closed account."
                            loop None
                        | Some bal ->
                            loop <| Some (bal + b)
                return! next
            }
        loop None)
    do account.Start()

    member this.openAccount() = 
       account.Post Open
    member this.getBalance() = 
        let balance = 
            account.PostAndReply <| fun c -> GetBalance c
        match balance with 
        | None -> failwith "This account is not currently open, it has no balance yet."
        | Some b -> b
    member this.Balance = 
        account.PostAndReply <| fun c -> GetBalance c
    member this.updateBalance b = 
        account.Post (UpdateBalance b)
    member this.closeAccount() = 
        account.Post Close


//type Balance = Balance of float option
//
//type BankMessage = 
//    | OpenAccount
//    | GetBalance of AsyncReplyChannel<Balance>
//    | UpdateBalance of Balance
//    | CloseAccount
//
//type Agent<'Msg> = MailboxProcessor<'Msg>
//
//type BankAccount() = 
//    let accountAgent = new Agent<BankMessage>(fun agent ->
//        let rec accountLoop (balance:Balance) = 
//            async {
//                let openUtil (oa:Balance) = 
//                    match oa with
//                    | Balance None -> Balance (Some 0.0)
//                    | oa -> failwith "Account already open" 
//                            oa
//
//                let updateBalanceUtil (amount:Balance) (balance:Balance) =
//                    match amount, balance with
//                    | Balance None, Balance None -> failwith "Account Closed"
//                    | Balance (Some(amount)), Balance None -> failwith "Account Closed"
//                    | Balance (Some(amount)), Balance (Some(balance)) -> accountLoop <| Balance (Some (balance + amount))
//                    | Balance None, Balance (Some(balance)) -> failwith "Bad Amount Input"
//
//                let! message = agent.Receive()
//                let accountAction = 
//                    match message with
//                    | OpenAccount -> (openUtil balance) |> accountLoop
//                    | GetBalance gb -> 
//                        gb.Reply balance
//                        accountLoop balance
//                    | UpdateBalance amount -> updateBalanceUtil amount balance
//                    | CloseAccount -> accountLoop (Balance None)
//                return! accountAction
//                }
//        accountLoop (Balance None) )
//    do accountAgent.Start()
//
//    member this.openAccount = 
//        accountAgent.Post OpenAccount
//
//    member this.getBalance (account:BankAccount) = 
//        let balance = 
//            accountAgent.PostAndReply <| fun gb -> GetBalance gb
//        match balance with 
//        | Balance None -> failwith "This account is not currently open, it has no balance yet."
//        | Balance (Some (balance)) -> balance
//
//    member this.updateBalance (amount:float) = 
//        accountAgent.Post (UpdateBalance (Balance(Some amount)))
//
//    member this.closeAccount = 
//        accountAgent.Post CloseAccount
//
//let mkBankAccount() = new BankAccount()
//let openAccount = mkBankAccount().
