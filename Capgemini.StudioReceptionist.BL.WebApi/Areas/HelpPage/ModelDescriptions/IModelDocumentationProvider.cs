using System;
using System.Reflection;

namespace Capgemini.StudioReceptionist.BL.WebApi.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}