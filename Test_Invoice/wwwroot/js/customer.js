

$(document).ready(function($){
    
    $("#list_customer").DataTable({
    });

    $("#add_customer").on("click", function(){
        
        var name = $("#add_cust_name").val()
        var address = $("#add_address").val()
        var selectedStatus = $("input[name='flexRadioDefault']:checked").val();
        var add_customer_type = $("#customer_type_selected").val()
        
        var state = selectedStatus == 1? true : false;
        
        $.ajax({
            method: "POST",
            url: "AddCustomer",
            data: { "CustName": name, "Adress": address,"Status": state, "CustomerTypeId": add_customer_type },
            success: function(data){
                
                if(name != "" && address != ""){
                    
                    Swal.fire({
                        title: "Exito",
                        text: data.Message,
                        icon: "success"
                    }).then(function(){
                        window.location.href = "GetAllCustomer"
                    })
                    
                }
                
                if(data.id == 2){
                    Swal.fire({
                        title: "Error",
                        text: data.Message,
                        icon: "warning"
                    })
                }
                
            },
            error:function(data){
                Swal.fire({
                    title: "Error",
                    text: data.Message,
                    icon: "warning"
                })
            }
        })
    })

    $("#on_customer_click_t").on("click", function(){
        window.location.href = "AddCustomer"
    })
    
    
    $("#update_customer_c").on("click", function(){
        debugger
        var update_cust_name = $("#update_cust_name").val()
        var update_address = $("#update_address").val()
        var selectedStatus = $("input[name='flexRadioDefault']:checked").val();
        var customer_type_selected = $("#customer_type_selected").val()
        var state = selectedStatus == 1? true : false;
        $.post("UpdateCustomer", {"CustName": update_cust_name, "Adress": update_address,"Status": state, "CustomerTypeId": customer_type_selected }, function(data){
            debugger
            if(data.id == 1){
                Swal.fire({
                    title: "Exito",
                    text : data.Message,
                    icon:"success"
                }).then(function(){
                    var result = window.location.href = ""
                    console.log(result)
                })
            }else{
                Swal.fire({
                    title: "Error",
                    text : data.Message,
                    icon:"warning"
                }).then(function(){
                    window.location.href = ""
                })
            }            
        })
    })   
})















