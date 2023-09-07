# net-async-local
`AsyncLocal<T>` in .Net can be used to create a context between different scopes like method calls. This is sample repo to demostrate usage of `AsyncLocal<T>`.
See how we created a context object and set it a name. Althoug `scopeNameHolder` in singleton `ContextProvider` is a static instance it will keep our state and pass it through to deeper method calls.

# How to Run This Sample
- Run this Asp.Net web api project
- Open `index.html` in your browser. 
- Press *start* button. It will open 30 new tab and you will see the same `ID` as you pass in the URL.