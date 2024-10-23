#### Dada la solución con 3 proyectos: Api, Model, Repository:

1. Mover la configuración de EF los atributos en el proyecto Model al proyecto Repository. Toda la configuración debería quedar vía Fluent Api
2. Verificar que la configuración haya queda idéntica. Para eso se puede ejecutar un Add-Migration, esta debería estar vacía. Si tiene cambios es porque alguna configuración no quedó bien.
3. Realizar un endpoint que reciba un id de pedido y devuelva el pedido con sus todas sus relaciones (OrderItem, Customer, Product). Se puede usar un DTO
4. Realizar un endpoint que genere un nuevo pedido (Order + OrderItem). Se puede usar un DTO
5. Realizar un endpoint que actualice un pedido (Order + OrderItem). Se puede usar un DTO
6. Implementar un Filter para el manejo y trackero de errores. Obtener el mensaje de la Exception e imprimirlo por consola usando Debug.WriteLine("Mensaje")
7. Implementar un Middleware para auditar todas las peticiones e imprimirlo por consola usando Debug.WriteLine("Mensaje")

#### Comandos para el manejo de migraciones:
 - Para agregar una nueva migración Add-Migration {NombreMigracion} -StartUpProject Api -Project Repository -Context ApplicationDbContext
 - Para eliminar una migración Remove-Migration -StartUpProject Api -Project Repository -Context ApplicationDbContext
 - Para actualizar la DB con las migraciones Update-Database -StartUpProject Api -Project Repository -Context ApplicationDbContext