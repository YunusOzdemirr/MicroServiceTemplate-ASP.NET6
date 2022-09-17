using System;
namespace MicroServiceTemplate.Domain.Common
{
    public static class SuccessMessage
    {
        public static string CreateSuccess(string entityName = null)
        {
            return entityName != null ? "Entity has been created. Entity Name: " + entityName : "Entity has been created.";
        }
        public static string UpdateSuccess(string entityName = null)
        {
            return entityName != null ? "Entity has beeen updated. Entity Name: " + entityName : "Entity has beeen updated.";
        }
        public static string GetSuccess(string entityName = null)
        {
            return entityName != null ? "Entity has been getted. Entity Name: " + entityName : "Entity has been getted.";
        }
        public static string DeleteSuccess(string entityName = null)
        {
            return  entityName != null ? "Entity has been deleted. Entity Name: " + entityName : "Entity has been deleted.";
        }
    }
}

