const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7114/orderHub")
    .build();

connection.start().then(() => console.log("Connected"))
    .catch(err => console.error(err));;


connection.on("OrderUpdated", function (order) {

  
    alert(order.custodycd);
    //let row = document.getElementById("order_" + order.orderId);

    //if (row) {
    //    row.querySelector(".status").innerText = order.status;
    //}

});

connection.on("ReceiveMessage", msg => {
    console.log(msg);
});

