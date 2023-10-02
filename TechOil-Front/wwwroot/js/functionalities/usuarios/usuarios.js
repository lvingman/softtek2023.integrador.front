var token = getCookie("Token");
    
    let table = new DataTable('#usuarios', {
        ajax:{
            url: `https://localhost:7071/api/Usuario`,
            dataSrc: "data.items",
            headers: {"Authorization": "Bearer " + token}
        },
        columns: [
            {data: 'id', title:'id'},
            {data: 'nombre', title:'nombre'},
            {data: 'dni', title: 'dni'},
            {data: 'idRol', title: 'idRol'},
            {data: 'contrasena', title: 'contrasena'},
            {data: 'email', title: 'email'},
            {
                data: function(data){
                    var botones =
                        `<td><button data-id="${data.id}" onclick='EditarUsuario(${JSON.stringify(data)})'>✏️</button></td>` +
                        `<td><button data-id="${data.id}" onclick='EliminarUsuario(${JSON.stringify(data)})'>🗑️</button></td>`;
                    return botones;
                }
            }
        ]
    });

function AgregarUsuario() {
    $.ajax({
        type: "GET",
        url: "/Usuario/UsuariosAddPartial",
        data: "",
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#usuariosAddPartial').html(resultado);
            $('#usuarioModal1').modal('show');
        }

    });
}


function EditarUsuario(data) {
    var id = data.id;
    var nombre = data.nombre;
    var dni = data.dni;
    var idRol = data.idRol;
    var contrasena = data.contrasena;
    var email = data.email;
    
    var usuarioViewModel = {
        Id: id,
        Nombre: nombre,
        Dni: dni,
        IdRol: idRol,
        Contrasena: contrasena,
        Email: email
    };
    
    $.ajax({
        type: "POST",
        url: "/Usuario/UsuariosAddPartial",
        data: JSON.stringify( usuarioViewModel),
        contentType:'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#usuariosAddPartial').html(resultado);
            $('#usuarioModal1').modal('show');
        }

    });
}

function EliminarUsuario(data) {
    var id = data.id;
    var nombre = data.nombre;
    var dni = data.dni;
    var idRol = data.idRol;
    var contrasena = data.contrasena;
    var email = data.email;

    var usuarioViewModel = {
        Id: id,
        Nombre: nombre,
        Dni: dni,
        IdRol: idRol,
        Contrasena: contrasena,
        Email: email
    };
    
    $.ajax({
        type: "POST",
        url: "/Usuario/UsuariosAddPartial",
        data: JSON.stringify(usuarioViewModel),
        contentType:'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#usuariosAddPartial').html(resultado);
            $('#usuarioModal2').modal('show');
        }

    });
}