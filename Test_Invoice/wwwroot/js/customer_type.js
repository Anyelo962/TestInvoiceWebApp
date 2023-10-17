

$(document).ready(function(){

    var js = jQuery.noConflict(true)

    js("#list_customer_type").DataTable({
    });

    js("#add_customer_type").on("click", function(){

        var customer_description = js("#add_description_customer_type").val()
        if(customer_description != null && customer_description.length > 2){
            js.ajax(
                {
                    method:"POST",
                    url:"AddCustomerType",
                    data: { "Description": customer_description },
                    success: function(data){
                        Swal.fire({
                            title:"Exito",
                            text: data.Message,
                            icon: "success"
                        }).then(function(){
                            window.location.href = "GetAllCustomerType"
                        })
                    },
                    onerror: function(data){
                        if(data.id == 2){
                            Swal.fire(
                                "Error",
                                data.Message,
                                "alert"
                            )
                        }

                    }
                }
            )
        }else{
            Swal.fire(
                "Advertencia",
                "Este campo no puede estar vacio, ni tener una longitud menor a 2",
                "warning"
            )
        }
        
       
    })
    
    js("#on_customer_type_click").on("click", function(){
        window.location.href = "AddCustomerType"
    });
    
    
    
    js("#update_customer_type").on("click", function(){
        
        
        Swal.fire("Update", "Üpdate completed", "success")
    })


})



