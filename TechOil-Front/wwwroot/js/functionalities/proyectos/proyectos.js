var token = getCookie("Token");

let table = new DataTable('#proyectos', {
    ajax:{
        url: `https://localhost:7071/api/Proyecto`,
        dataSrc: "data.items",
        headers: {"Authorization": "Bearer " + token}
    },
    columns: [
        {data: 'id', title:'id'},
        {data: 'nombre', title:'nombre'},
        {data: 'direccion', title:'direccion'},
        {data: 'idEstado', title: 'idEstado'},
        {data: 'estado', title: 'estado'},
        {
            data: function(data){
                var botones =
                    `<td><button data-id="${data.id}" onclick='EditarProyecto(${JSON.stringify(data)})'>✏️</button></td>` +
                    `<td><button data-id="${data.id}" onclick='EliminarProyecto(${JSON.stringify(data)})'>🗑️</button></td>`;
                return botones;
            }
        }
    ]
});

function AgregarProyecto() {
    $.ajax({
        type: "GET",
        url: "/Proyecto/ProyectosAddPartial",
        data: "",
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#proyectosAddPartial').html(resultado);
            $('#proyectoModal1').modal('show');
        }

    });
}


function EditarProyecto(data) {

    var id = data.id;
    var nombre = data.nombre;
    var direccion = data.direccion;
    var idEstado = data.idEstado;
    var estado = data.estado;


    var proyectoViewModel = {
        Id: id,
        Nombre: nombre,
        Direccion: direccion,
        IdEstado: idEstado,
        Estado: estado
    };

    $.ajax({
        type: "POST",
        url: "/Proyecto/ProyectosAddPartial",
        data: JSON.stringify( proyectoViewModel),
        contentType:'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#proyectosAddPartial').html(resultado);
            $('#proyectoModal1').modal('show');
        }

    });
}

function EliminarProyecto(data) {

    var id = data.id;
    var nombre = data.nombre;
    var direccion = data.direccion;
    var idEstado = data.idEstado;
    var estado = data.estado;



    var proyectoViewModel = {
        Id: id,
        Nombre: nombre,
        Direccion: direccion,
        IdEstado: idEstado,
        Estado: estado
    };

    $.ajax({
        type: "POST",
        url: "/Proyecto/ProyectosAddPartial",
        data: JSON.stringify(proyectoViewModel),
        contentType:'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#proyectosAddPartial').html(resultado);
            $('#proyectoModal2').modal('show');
        }

    });
}