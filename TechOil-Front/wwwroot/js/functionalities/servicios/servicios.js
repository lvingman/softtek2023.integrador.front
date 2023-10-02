var token = getCookie("Token");

let table = new DataTable('#servicios', {
    ajax:{
        url: `https://localhost:7071/api/Servicio`,
        dataSrc: "data.items",
        headers: {"Authorization": "Bearer " + token}
    },
    columns: [
        {data: 'id', title:'id'},
        {data: 'descripcion', title:'descripcion'},
        {data: 'valorHora', title:'valorHora'},
        {
            data: function(data){
                var botones =
                    `<td><button data-id="${data.id}" onclick='EditarServicio(${JSON.stringify(data)})'>✏️</button></td>` +
                    `<td><button data-id="${data.id}" onclick='EliminarServicio(${JSON.stringify(data)})'>🗑️</button></td>`;
                return botones;
            }
        }
    ]
});

function AgregarServicio() {
    $.ajax({
        type: "GET",
        url: "/Servicio/ServiciosAddPartial",
        data: "",
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#serviciosAddPartial').html(resultado);
            $('#servicioModal1').modal('show');
        }

    });
}


function EditarServicio(data) {

    var id = data.id;
    var descripcion = data.descripcion;
    var valorHora = data.valorHora;


    var servicioViewModel = {
        Id: id,
        Descripcion: descripcion,
        ValorHora: valorHora
    };

    $.ajax({
        type: "POST",
        url: "/Servicio/ServiciosAddPartial",
        data: JSON.stringify( servicioViewModel),
        contentType:'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#serviciosAddPartial').html(resultado);
            $('#servicioModal1').modal('show');
        }

    });
}

function EliminarServicio(data) {

    var id = data.id;
    var descripcion = data.descripcion;
    var valorHora = data.valorHora;



    var servicioViewModel = {
        Id: id,
        Descripcion: descripcion,
        ValorHora: valorHora
    };

    $.ajax({
        type: "POST",
        url: "/Servicio/ServiciosAddPartial",
        data: JSON.stringify(servicioViewModel),
        contentType:'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#serviciosAddPartial').html(resultado);
            $('#servicioModal2').modal('show');
        }

    });
}