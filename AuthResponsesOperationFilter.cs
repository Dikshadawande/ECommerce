﻿using System;


    public class AuthResponsesOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var authAttributes = context.MethodInfo.DeclaringType?.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<AuthorizeAttribute>();

            if (authAttributes == null || !authAttributes.Any()) return;

            var securityRequirement = new OpenApiSecurityRequirement()
        {
            {
                // Put here you own security scheme, this one is an example
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                    },
                    Scheme =JwtBearerDefaults.AuthenticationScheme,
                    Name = HeaderNames.Authorization,
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT"
                },
                new List<string>()
            }
        };

            operation.Security = new List<OpenApiSecurityRequirement> { securityRequirement };
            operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
        }
    }
