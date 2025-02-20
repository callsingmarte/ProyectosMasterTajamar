//Procedimiento almacenado
function insertFamily(family)
{
    var collection = getContext().getCollection();

    //verificar si la familia existe
    var query = `SELECT * FROM c WHERE c.id = "${family.id}"`;
    var isAccepted = collection.queryDocuments(collection.getSelfLink(), query,
        function (err, documents, responseOptions) {
            if (err) throw new Error("Error en la consulta " + err.message);
            if (documents.length > 0) {
                throw new Error("Una familia con este id ya existe")
            }
            else {
                //Insertamos la familia
                var isInserted = collection.createDocument(collection.getSelfLink(), family,
                    function (err, documentCreated) {
                        if (err) throw new Error("Error al insertar: " + err.message)
                        getContext().getResponse().setBody(documentCreated);
                    }
                );
                if (!isInserted) throw new Error("Error al aceptar la insercion")
            }
        }
    );

    if (!isAccepted) throw new Error("Error al aceptar la consulta");

}