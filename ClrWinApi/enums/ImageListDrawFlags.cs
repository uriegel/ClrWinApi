namespace ClrWinApi;

[Flags]
public enum ImageListDrawFlags
{
    /// <summary>
    /// Draws the image using the background color for the image list. If the background color is the CLR_NONE value, the image is drawn transparently using the mask.
    /// </summary>
    Normal,
    /// <summary>
    /// Draws the image transparently using the mask, regardless of the background color. This value has no effect if the image list does not contain a mask.
    /// </summary>
    Transparent,
    /// <summary>
    /// Draws the image, blending 25 percent with the blend color specified by rgbFg. This value has no effect if the image list does not contain a mask.
    /// </summary>
    Blend25,
    /// <summary>
    /// Same as ILD_BLEND25
    /// </summary>
    Focus = 0x2,
    /// <summary>
    /// Draws the image, blending 50 percent with the blend color specified by rgbFg. This value has no effect if the image list does not contain a mask.
    /// </summary>
    Blend50 = 0x4,
    /// <summary>
    /// Same as ILD_BLEND50.
    /// </summary>
    Selected = 0x4,
    /// <summary>
    /// Same as ILD_BLEND50.
    /// </summary>
    Blend = 0x4,
    /// <summary>
    /// Draws the mask.
    /// </summary>
    Mask = 0x10,
    /// <summary>
    /// If the overlay does not require a mask to be drawn, set this flag.
    /// </summary>
    Image = 0x20,
    /// <summary>
    /// Draws the image using the raster operation code specified by the dwRop member.
    /// </summary>
    Rop = 0x40,
    /// <summary>
    /// To extract the overlay image from the fStyle member, use the logical AND to combine fStyle with the ILD_OVERLAYMASK value.
    /// </summary>
    OverlayMask = 0xF00,
    /// <summary>
    /// Preserves the alpha channel in the destination.
    /// </summary>
    PreserveAlpha = 0x1000,
    /// <summary>
    /// Causes the image to be scaled to cx, cy instead of being clipped.
    /// </summary>
    Scale = 0x2000,
    /// <summary>
    /// Scales the image to the current dpi of the display.
    /// </summary>
    DpiScale = 0x4000,
    /// <summary>
    /// Windows Vista and later. Draw the image if it is available in the cache. Do not extract it automatically. The called draw method returns E_PENDING to the calling component, which should then take an alternative action, such as, provide another image and queue a background task to force the image to be loaded via ForceImagePresent using the ILFIP_ALWAYS flag. The ILD_ASYNC flag then prevents the extraction operation from blocking the current thread and is especially important if a draw method is called from the user interface (UI) thread.
    /// </summary>
    Async = 0x8000
}

