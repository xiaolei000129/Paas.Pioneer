using Paas.Pioneer.Admin.Core.Domain.Shared.Const;
using Volo.Abp.TextTemplating;
using Volo.Abp.TextTemplating.Scriban;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.TextTemplatingDefinition
{
    public class AdminCoreTemplateDefinitionProvider : TemplateDefinitionProvider
    {
        public override void Define(ITemplateDefinitionContext context)
        {
            context.Add(
                new TemplateDefinition(RazorTestTemplatesConsts.PaasPioneerHttpApiControllers)
                    .WithScribanEngine()
                    .WithVirtualFilePath(
                        $"{TemplatesConstsFileUrlConsts.PaasPioneerHttpApiControllers}Controllers.tpl", //template content path
                        isInlineLocalized: true
                    )
            );

            context.Add(
                new TemplateDefinition(RazorTestTemplatesConsts.PaasPioneerApplicationContractsService)
                    .WithScribanEngine()
                    .WithVirtualFilePath(
                        $"{TemplatesConstsFileUrlConsts.PaasPioneerApplicationContractsService}IService.tpl", //template content path
                        isInlineLocalized: true
                    )
            );

            context.Add(
                new TemplateDefinition(RazorTestTemplatesConsts.PaasPioneerApplicationContractsAddInput)
                    .WithScribanEngine()
                    .WithVirtualFilePath(
                        $"{TemplatesConstsFileUrlConsts.PaasPioneerApplicationContractsAddInput}AddInput.tpl", //template content path
                        isInlineLocalized: true
                    )
            );

            context.Add(
                new TemplateDefinition(RazorTestTemplatesConsts.PaasPioneerApplicationContractsGetPageListInput)
                    .WithScribanEngine()
                    .WithVirtualFilePath(
                        $"{TemplatesConstsFileUrlConsts.PaasPioneerApplicationContractsGetPageListInput}GetPageListInput.tpl", //template content path
                        isInlineLocalized: true
                    )
            );

            context.Add(
                new TemplateDefinition(RazorTestTemplatesConsts.PaasPioneerApplicationContractsUpdateInput)
                    .WithScribanEngine()
                    .WithVirtualFilePath(
                        $"{TemplatesConstsFileUrlConsts.PaasPioneerApplicationContractsUpdateInput}UpdateInput.tpl", //template content path
                        isInlineLocalized: true
                    )
            );

            context.Add(
                new TemplateDefinition(RazorTestTemplatesConsts.PaasPioneerApplicationContractsGetOutput)
                    .WithScribanEngine()
                    .WithVirtualFilePath(
                        $"{TemplatesConstsFileUrlConsts.PaasPioneerApplicationContractsGetOutput}GetOutput.tpl", //template content path
                        isInlineLocalized: true
                    )
            );

            context.Add(
                new TemplateDefinition(RazorTestTemplatesConsts.PaasPioneerApplicationContractsGetPageListOutput)
                    .WithScribanEngine()
                    .WithVirtualFilePath(
                        $"{TemplatesConstsFileUrlConsts.PaasPioneerApplicationContractsGetPageListOutput}GetPageListOutput.tpl", //template content path
                        isInlineLocalized: true
                    )
            );


            context.Add(
                new TemplateDefinition(RazorTestTemplatesConsts.PaasPioneerApplicationService)
                    .WithScribanEngine()
                    .WithVirtualFilePath(
                        $"{TemplatesConstsFileUrlConsts.PaasPioneerApplicationService}Service.tpl", //template content path
                        isInlineLocalized: true
                    )
            );

            context.Add(
                new TemplateDefinition(RazorTestTemplatesConsts.PaasPioneerApplicationMapConfig)
                    .WithScribanEngine()
                    .WithVirtualFilePath(
                        $"{TemplatesConstsFileUrlConsts.PaasPioneerApplicationMapConfig}_MapConfig.tpl", //template content path
                        isInlineLocalized: true
                    )
            );

            context.Add(
                new TemplateDefinition(RazorTestTemplatesConsts.PaasPioneerEntityFrameworkCoreRepository)
                    .WithScribanEngine()
                    .WithVirtualFilePath(
                        $"{TemplatesConstsFileUrlConsts.PaasPioneerEntityFrameworkCore}Repository.tpl", //template content path
                        isInlineLocalized: true
                    )
            );

            context.Add(
                new TemplateDefinition(RazorTestTemplatesConsts.PaasPioneerDomainIRepository)
                    .WithScribanEngine()
                    .WithVirtualFilePath(
                        $"{TemplatesConstsFileUrlConsts.PaasPioneerDomain}IRepository.tpl", //template content path
                        isInlineLocalized: true
                    )
            );

            context.Add(
               new TemplateDefinition(RazorTestTemplatesConsts.VueJs)
                   .WithScribanEngine()
                   .WithVirtualFilePath(
                       $"{TemplatesConstsFileUrlConsts.VueJs}Js.tpl", //template content path
                       isInlineLocalized: true
                   )
           );

            context.Add(
              new TemplateDefinition(RazorTestTemplatesConsts.HtmlVue)
                  .WithScribanEngine()
                  .WithVirtualFilePath(
                      $"{TemplatesConstsFileUrlConsts.HtmlVue}Html.tpl", //template content path
                      isInlineLocalized: true
                  )
          );

        }
    }
}
