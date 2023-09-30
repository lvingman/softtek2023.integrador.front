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
        {data: 'email', title: 'email'},
        {data: 'rol.nombre', title: 'rol'},
        {
            data: function(data){
                var botones =
                    `<td>
                        <a href='javascript:EditarUsuario(${JSON.stringify(data)})'>
                        <i class="fa-solid fa-pen-to-square editarUsuario"></i>
                    </td>`+
                    `<td>
                        <a href='javascript:EliminarUsuario(${JSON.stringify(data)})'>
                        <i class="fa-solid fa-trash eliminarUsuario"></i>
                    </td>`
                return botones;
            }
        }
    ]
});

function AgregarUsuario() {
    $.ajax({
        type: "GET",
        url: "/Usuarios/UsuariosAddPartial",
        data: "",
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#usuariosAddPartial').html(resultado);
            $('#usuarioModal').modal('show');
        }

    });
}


function EditarUsuario(data) {
    debugger
    $.ajax({
        type: "POST",
        url: "/Usuarios/UsuariosAddPartial",
        data: JSON.stringify(data),
        contentType:'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#usuariosAddPartial').html(resultado);
            $('#usuarioModal').modal('show');
        }

    });
}

function EliminarUsuario(data) {
    $.ajax({
        type: "GET",
        url: "/Usuarios/EliminarUsuario",
        data: JSON.stringify(data),
        'dataType': "html",
        success: function (resultado) {

        }

    });
}