let table = new DataTable('#usuarios', {
    ajax:{
        url: `https://localhost:7071/api/Usuario`,
        dataSrc: "data.items",
        headers: {"Authorization": "Bearer " + }
    },
    columns: [
        {data: 'id', title:'id'},
        {data: 'nombre', title:'nombre'},
        {data: 'dni', title: 'dni'},
        {data: 'email', title: 'email'},
        {data: 'rol.nombre', title: 'rol'}
    ]
})