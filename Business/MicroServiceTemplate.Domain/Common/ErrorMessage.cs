using System;
namespace MicroServiceTemplate.Domain.Common
{
    public static class ErrorMessage
    {
        public static string CreateFail(string entityName = null)
        {
            return "Entity has occured an error when creating." + entityName != null ? " Entity Name: " + entityName : "";
        }
        public static string UpdateFail(string entityName = null)
        {
            return "Entity has occurred an error when updating." + entityName != null ? " Entity Name: " + entityName : "";
        }
        public static string GetFail(string entityName = null)
        {
            return "Entity has occurred an error when getting." + entityName != null ? " Entity Name: " + entityName : "";
        }
        public static string DeleteFail(string entityName = null)
        {
            return "Entity has occurred an error when deleting." + entityName != null ? " Entity Name: " + entityName : "";
        }
    }
}

