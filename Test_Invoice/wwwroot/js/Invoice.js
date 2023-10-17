






$(document).ready(function($){

    $("#invoice_table").DataTable({
    });
    
    $("#list_invoice").on("click", function(){
        window.location.href = "AddInvoice"
    })

    $("#add_invoice"). attr("disabled", true);    
    
    $("#calculate_itbis").on("click", function(){
        var add_quantity_details = $("#add_quantity_details").val()
        var add_price_details = $("#add_price_details").val()

        $("#add_total_itbit_details").val(( add_quantity_details * add_price_details) * 0.18)
        var result = (add_quantity_details * add_price_details) * 0.18
        $("#add_sub_total_details").val(( (add_quantity_details * add_price_details)) + result )

        $("#add_total_details").val(((add_quantity_details * add_price_details)) + result )

        $("#add_invoice"). attr("disabled", false);
        
    })



    $("#add_invoice").on("click", function(){
        var add_quantity_details = $("#add_quantity_details").val()
        var add_price_details = $("#add_price_details").val()
        var add_total_itbit_details = $("#add_total_itbit_details").val()
        var add_sub_total_details = $("#add_sub_total_details").val()
        var add_total_details = $("#add_total_details").val()
        var customerId = $("#IdCustomer").val()
        
        
        
        $.post("AddInvoice", {"CustomerId":customerId, "Qty":add_quantity_details, "Price":add_price_details, "TotalItbis": add_total_itbit_details, "SubTotal": add_sub_total_details, "Total": add_total_details }, function(data){
            
            if(data.id == 1){
                Swal.fire({
                    title: "Exito",
                    text : data.Message,
                    icon:  "success"
                }).then(function(){
                    window.location.href = "GetAllInvoice"
                });
            }
      
            
        })
        
        

    })
})
























