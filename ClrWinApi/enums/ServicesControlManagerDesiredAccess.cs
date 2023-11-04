namespace ClrWinApi;

[Flags]
public enum ServicesControlManagerDesiredAccess 
{
    /// <summary>
    /// Includes STANDARD_RIGHTS_REQUIRED, in addition to all access rights in this table.
    /// </summary>
    AllAccess = 0xF003F,
    /// <summary>
    /// Required to call the CreateService function to create a service object and add it to the database.
    /// </summary>
    CreateService = 0x0002,	
    /// <summary>
    /// Required to connect to the service control manager.
    /// </summary>
    Connect = 0x0001,
    /// <summary>
    /// Required to call the EnumServicesStatus or EnumServicesStatusEx function to list the services that are in the database.
    /// Required to call the NotifyServiceStatusChange function to receive notification when any service is created or deleted.
    /// </summary>
    EnumerateService =0x0004,
    /// <summary>
    /// Required to call the LockServiceDatabase function to acquire a lock on the database.
    /// </summary>
    Lock = 0x0008,	
    /// <summary>
    /// Required to call the NotifyBootConfigStatus function.
    /// </summary>
    ModifyBootConfig = 0x0020,	
    /// <summary>
    /// Required to call the QueryServiceLockStatus function to retrieve the lock status information for the database.
    /// </summary>
    QueryLockStatus = 0x0010	
}







