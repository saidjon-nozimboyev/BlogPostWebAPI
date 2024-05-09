﻿global using BlogPostWebAPI.Common.Exceptions;
global using BlogPostWebAPI.Common.Helpers;
global using BlogPostWebAPI.Common.Security;
global using BlogPostWebAPI.DTOs.UserDTOs;
global using BlogPostWebAPI.Entities;
global using BlogPostWebAPI.Interfaces.Repositories;
global using BlogPostWebAPI.Interfaces.Services;
global using Microsoft.Extensions.Caching.Memory;
global using System.Net;
global using Microsoft.IdentityModel.Tokens;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;
global using MailKit.Net.Smtp;
global using MailKit.Security;
global using MimeKit;
global using MimeKit.Text;
global using BlogPostWebAPI.DbContexts;
global using Microsoft.EntityFrameworkCore;
global using System.Linq.Expressions;
global using BlogPostWebAPI.Interfaces.Common;
global using BlogPostWebAPI.Enums;
global using System.ComponentModel.DataAnnotations.Schema;
global using BlogPostWebAPI.Common.Attributes; 
global using System.ComponentModel.DataAnnotations;
global using System.Text.RegularExpressions;
global using System.Security.Cryptography;
global using BlogPostWebAPI.Common.Validators;