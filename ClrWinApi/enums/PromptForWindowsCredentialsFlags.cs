namespace ClrWinApi;

[Flags]
public enum PromptForWindowsCredentialsFlags : uint
{
    /// <summary>
    /// The caller is requesting that the credential provider return the user name and password in plain text.
    /// This value cannot be combined with SECURE_PROMPT.
    /// </summary>
    Generic = 0x1,
    /// <summary>
    /// The Save check box is displayed in the dialog box.
    /// </summary>
    CheckBox = 0x2,
    /// <summary>
    /// Only credential providers that support the authentication package specified by the pulAuthPackage parameter should be enumerated.
    /// This value cannot be combined with CREDUIWIN_IN_CRED_ONLY.
    /// </summary>
    AuthPackageOnly = 0x10,
    /// <summary>
    /// Only the credentials specified by the pvInAuthBuffer parameter for the authentication package specified by the pulAuthPackage parameter should be enumerated.
    /// If this flag is set, and the pvInAuthBuffer parameter is NULL, the function fails.
    /// This value cannot be combined with CREDUIWIN_AUTHPACKAGE_ONLY.
    /// </summary>
    InCredOnly = 0x20,
    /// <summary>
    /// Credential providers should enumerate only administrators. This value is intended for User Account Control (UAC) purposes only. We recommend that external callers not set this flag.
    /// </summary>
    EnumerateAdmins = 0x100,
    /// <summary>
    /// Only the incoming credentials for the authentication package specified by the pulAuthPackage parameter should be enumerated.
    /// </summary>
    EnumerateCurrentUser = 0x200,
    /// <summary>
    /// The credential dialog box should be displayed on the secure desktop. This value cannot be combined with CREDUIWIN_GENERIC.
    /// Windows Vista:  This value is supported beginning with Windows Vista with SP1.
    /// </summary>
    SecurePrompt = 0x1000,
    /// <summary>
    /// The credential dialog box is invoked by the SspiPromptForCredentials function, and the client is prompted before a prior handshake. If SSPIPFC_NO_CHECKBOX is passed in the pvInAuthBuffer parameter, then the credential provider should not display the check box.
    /// Windows Vista:  This value is supported beginning with Windows Vista with SP1.
    /// </summary>
    PrePrompting = 0x2000,
    /// <summary>
    /// The credential provider will not pack the AAD authority name. This is only applied to Azure AD joined devices.
    /// Windows 10, version 1607:  This value is supported beginning with Windows 10, version 1607.
    /// </summary>
    Forty000 = 0x40000,
    /// <summary>
    /// The credential provider should align the credential BLOB pointed to by the ppvOutAuthBuffer parameter to a 32-bit boundary, even if the provider is running on a 64-bit system.
    /// </summary>
    Pack32Wow = 0x10000000,
    /// <summary>
    /// Windows Hello credentials will be packed in a smart card auth buffer. This only applies to the face, fingerprint, and PIN credential providers.
    /// Windows 10, version 1809:  This value is supported beginning with Windows 10, version 1809.
    /// </summary>
    Eight0000000 = 0x80000000,
}
