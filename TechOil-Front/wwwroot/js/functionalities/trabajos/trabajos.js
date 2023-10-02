var token = getCookie("Token");

let table = new DataTable('#trabajos', {
    ajax:{
        url: `https://localhost:7071/api/Trabajo`,
        dataSrc: "data.items",
        headers: {"Authorization": "Bearer " + token}
    },
    columns: [
        {data: 'id', title:'id'},
        {data: 'fecha', title:'fecha'},
        {data: 'idProyecto', title:'idProyecto'},
        {data: 'idServicio', title: 'idServicio'},
        {data: 'cantidadHoras', title: 'cantidadHoras'},
        {data: 'valorHora', title: 'valorHora'},
        {data: 'costo', title: 'costo'},
        {
            data: function(data){
                var botones =
                    `<td><button data-id="${data.id}" onclick='EditarTrabajo(${JSON.stringify(data)})'>✏️</button></td>` +
                    `<td><button data-id="${data.id}" onclick='EliminarTrabajo(${JSON.stringify(data)})'>🗑️</button></td>`;
                return botones;
            }
        }
    ]
});

function AgregarTrabajo() {
    $.ajax({
        type: "GET",
        url: "/Trabajo/TrabajosAddPartial",
        data: "",
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#trabajosAddPartial').html(resultado);
            $('#trabajoModal1').modal('show');
        }

    });
}


function EditarTrabajo(data) {
    
    var id = data.id;
    var fecha = data.fecha;
    var idProyecto = data.idProyecto;
    var idServicio = data.idServicio;
    var cantidadHoras = data.cantidadHoras;
    var valorHora = data.valorHora;
  

    var trabajoViewModel = {
        Id: id,
        Fecha: fecha,
        IdProyecto: idProyecto,
        IdServicio: idServicio,
        CantidadHoras: cantidadHoras,
        ValorHora: valorHora
    };

    $.ajax({
        type: "POST",
        url: "/Trabajo/TrabajosAddPartial",
        data: JSON.stringify( trabajoViewModel),
        contentType:'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#trabajosAddPartial').html(resultado);
            $('#trabajoModal1').modal('show');
        }

    });
}

function EliminarTrabajo(data) {
  
    var id = data.id;
    var fecha = data.fecha;
    var idProyecto = data.idProyecto;
    var idServicio = data.idServicio;
    var cantidadHoras = data.cantidadHoras;
    var valorHora = data.valorHora;


    var trabajoViewModel = {
        Id: id,
        Fecha: fecha,
        IdProyecto: idProyecto,
        IdServicio: idServicio,
        CantidadHoras: cantidadHoras,
        ValorHora: valorHora
    };

    $.ajax({
        type: "POST",
        url: "/Trabajo/TrabajosAddPartial",
        data: JSON.stringify(trabajoViewModel),
        contentType:'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#trabajosAddPartial').html(resultado);
            $('#trabajoModal2').modal('show');
        }

    });
}