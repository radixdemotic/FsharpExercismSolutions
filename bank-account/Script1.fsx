open System.Threading

let main() =
// create a new thread passing it a lambda function
    let thread = new Thread(fun () ->
// print a message on the newly created thread
        printfn "Created thread: %i" Thread.CurrentThread.ManagedThreadId)
// start the new thread
    thread.Start()
// print an message on the original thread
    printfn "Orginal thread: %i" Thread.CurrentThread.ManagedThreadId
// wait for the created thread to exit
    thread.Join()

let x() = do main()