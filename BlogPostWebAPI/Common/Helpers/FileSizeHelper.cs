﻿namespace BlogPostWebAPI.Common.Helpers;

public class FileSizeHelper
{ 
    public static double ByteToMb(long size)
        => (double)size / 1024 / 1024;
}
