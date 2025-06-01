using System.Text.Json;
using MDDPlatform.ModelTransformations.Application.Patterns.Common;
using MDDPlatform.ModelTransformations.Application.Patterns.ModelToText;
using MDDPlatform.ModelTransformations.Application.Patterns.Object2Concept;
using MDDPlatform.ModelTransformations.Application.Patterns.Object2Object;
using MDDPlatform.ModelTransformations.Application.Patterns.RelationalDimension;
using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Infrastructure.Data.Models;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Seeders.PatternTemplates;
public class PatternInstanceTemplateRegistry : IPatternInstanceTemplateRgistry
{
    public PatternInstanceTemplate Convert_Controller_Endpoint_to_the_Operation_and_Attributes()
    {
        Guid Id=Guid.Parse("fbb254c1-7c3c-5e4c-ad90-3addc0321db1");
        Guid PatternId=ReplaceRelationWithOperationAttributes.PatternId;
        var PatternName="ReplaceRelationWithOperationAttributes";
        var PatternCategory="Object2Concept";
        var Title="Convert Controller endpoint to operation & attributes";
        var Name="Controller_Endpoint_to_Operation&Attributes";
        var FieldValues = new List<FieldValueDocument>() 
        {
                new FieldValueDocument("ConceptNode","ApiController.Concept"),
                new FieldValueDocument("OperationNode","HTTPPost.Endpoint.Concept"),
                new FieldValueDocument("OperationNameProperty","OperationNode.Name"),
                new FieldValueDocument("OperationOutputProperty","Task"),
                new FieldValueDocument("ConceptToOperationRelation","hasEndpoint"),
                new FieldValueDocument("OperationToInputParametersRelation","hasRequestBody")
        };
        var Variables = new List<FieldDocument>(){
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Convert_CRAC_model_to_CQRS_CommandHandler()
    {
        Guid Id= Guid.Parse("886f653f-a88c-ed42-938c-641e9fd0e870");
        var PatternId= ReplaceRelationWithForkNode.PatternId;
        var PatternName= "ReplaceRelationWithForkNode";
        var PatternCategory= "Object2Object";
        var Title= "Convert CRAC model to CQRS - CommandHandler";
        var Name= "CRAC_to_CQRS_CommandHandler";
        var FieldValues = new List<FieldValueDocument>() 
        {
            new FieldValueDocument("SourceNode","Command.Concept"),
            new FieldValueDocument("DestinationNode","Event.Concept"),
            new FieldValueDocument("SourceToDestinationRelation","publishFact"),
            new FieldValueDocument("ForkNode","CommandHandler.Concept"),
            new FieldValueDocument("ForkToSourceRelation","canHandle"),
            new FieldValueDocument("ForkToDestinationRelation","canPublish"),
            new FieldValueDocument("ForkNodeInstanceName","SourceNode.Name"),
            new FieldValueDocument("ForkNodeInstanceNamePrefix",""),
            new FieldValueDocument("ForkNodeInstanceNamePostfix","Handler")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)    
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Convert_CRAC_model_to_CQRS_EventHandler()
    {
        Guid Id=Guid.Parse("72c9d297-c70d-6142-9170-228fbaa9fbe7");
        Guid PatternId=MapRelatedObjects.PatternId;
        var PatternName="MapRelatedObjects";
        var PatternCategory="Object2Object";
        var Title="Convert CRAC Model to CQRS - EventHandler";
        var Name="CRAC_to_CQRS_EventHandler";

        var FieldValues = new List<FieldValueDocument>() 
        {
            new FieldValueDocument("InputSource","DomainConcept.Concept"),
            new FieldValueDocument("InputDestination","Event.Concept"),
            new FieldValueDocument("InputSourceToDestinationRelation","isInterestedIn"),
            new FieldValueDocument("OutputSource","EventHandler.Concept"),
            new FieldValueDocument("OutputDestination","Event.Concept"),
            new FieldValueDocument("OutputSourceToDestinationRelation","canHandle"),
            new FieldValueDocument("OutputSourceInstanceExpression","InputDestination.Name+Handler"),
            new FieldValueDocument("OutputDestinationInstanceExpression","InputDestination.Name")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Convert_CRAC_Responsibility_To_Domain_Concept_Operation()
    {
        Guid Id=Guid.Parse("c072adca-e697-4a48-bff5-447ed515dc88");
        var PatternId=MapRelatedObjects.PatternId;
        var PatternName="MapRelatedObjects";
        var PatternCategory="Object2Object";
        var Title="Convert CRAC Responsibility to Domain Concept Operation";
        var Name="CRAC_Responsibility_to_DomainConcept_Operation";
        var FieldValues = new List<FieldValueDocument>() 
        {
            new FieldValueDocument("InputSource","DomainConcept.Concept"),
            new FieldValueDocument("InputDestination","Command.Concept"),
            new FieldValueDocument("InputSourceToDestinationRelation","isResponsibleFor"),
            new FieldValueDocument("OutputSource","DomainConcept.Concept"),
            new FieldValueDocument("OutputDestination","Operation.Concept"),
            new FieldValueDocument("OutputSourceToDestinationRelation","hasOperation"),
            new FieldValueDocument("OutputSourceInstanceExpression","InputSource.Name"),
            new FieldValueDocument("OutputDestinationInstanceExpression","InputDestination.Name")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();

    }

    public PatternInstanceTemplate Convert_Dispatched_Command_to_the_Controller_Endpoint()
    {
        Guid Id=Guid.Parse("58ea9c30-1e24-8140-a1c3-0e4b8130d6cf");
        Guid PatternId=ReplaceRelationWithChainOfNodes.PatternId;
        var PatternName="ReplaceRelationWithChainOfNodes";
        var PatternCategory="Object2Object";
        var Title="Convert dispatched command to controller endpoint";
        var Name="Dispatched_Command_to_Controller_Endpoint";
        var FieldValues = new List<FieldValueDocument>() 
        {
            new FieldValueDocument("SourceNode","ApiController.Concept"),
            new FieldValueDocument("DestinationNode","Command.Concept"),
            new FieldValueDocument("SourceToDestinationRelation","dispatchCommand"),
            new FieldValueDocument("FirstNode","ApiController.Concept"),
            new FieldValueDocument("MiddleNode","HTTPPost.Endpoint.Concept"),
            new FieldValueDocument("LastNode","Command.Concept"),
            new FieldValueDocument("FirstToMiddleNodeRelation","hasEndpoint"),
            new FieldValueDocument("MiddleToLastNodeRelation","hasRequestBody"),
            new FieldValueDocument("FirstNodeInstanceExpression","SourceNode.Name"),
            new FieldValueDocument("MiddleNodeInstanceExpression","DestinationNode.Name+Endpoint"),
            new FieldValueDocument("LastNodeInstanceExpression","DestinationNode.Name")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();

    }

    public PatternInstanceTemplate Create_command_handler_constructor_In_CQRS_Model()
    {
        Guid Id=Guid.Parse("ba1df5ea-77b4-564f-b2af-e179d803b316");
        Guid PatternId=ReplaceRelationWithAction.PatternId;
        var PatternName="ReplaceRelationWithAction";
        var PatternCategory="Object2Concept";
        var Title="CQRS - Create command handler constructor";
        var Name="CQRS_Relation_to_CommandHandler_Constructor";

        var FieldValues = new List<FieldValueDocument>() 
        {
            new FieldValueDocument("ConceptNode","CommandHandler.Concept"),
            new FieldValueDocument("OperationNameProperty","ConceptNode.Name"),
            new FieldValueDocument("OperationOutputProperty",""),
            new FieldValueDocument("OperationInputsRelation","hasCollaborator")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };

        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Create_Event_handler_constructor_In_CQRS_Model()
    {
        Guid Id=Guid.Parse("b8899551-91de-2f40-999c-ac8d5f445dbe");
        Guid PatternId=ReplaceRelationWithAction.PatternId;
        var PatternName="ReplaceRelationWithAction";
        var PatternCategory="Object2Concept";
        var Title="CQRS - Create event handler constructor";
        var Name="CQRS_Relation_to_EventHandler_Constructor";
        var FieldValues = new List<FieldValueDocument>() 
        {
            new FieldValueDocument("ConceptNode","EventHandler.Concept"),
            new FieldValueDocument("OperationNameProperty","ConceptNode.Name"),
            new FieldValueDocument("OperationOutputProperty",""),
            new FieldValueDocument("OperationInputsRelation","hasCollaborator")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };

        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Create_handle_method_of_command_handler_In_CQRS_Model()
    {
        Guid Id=Guid.Parse("25e09081-14a3-3142-9843-ff9fc174d112");
        Guid PatternId=ReplaceRelationWithAction.PatternId;
        var PatternName="ReplaceRelationWithAction";
        var PatternCategory="Object2Concept";
        var Title="CQRS - Create handle method of command handler";
        var Name="CQRS_Relation_to_CommandHandler_Handle_method";

        var FieldValues = new List<FieldValueDocument>() 
        {
            new FieldValueDocument("ConceptNode","CommandHandler.Concept"),
            new FieldValueDocument("OperationNameProperty","HandleAsync"),
            new FieldValueDocument("OperationOutputProperty","Task"),
            new FieldValueDocument("OperationInputsRelation","canHandle")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Create_handle_method_of_Event_handler_In_CQRS_Model()
    {
        Guid Id=Guid.Parse("75a105e1-fcc7-b944-ab7b-7a606c042168");
        Guid PatternId=ReplaceRelationWithAction.PatternId;
        var PatternName="ReplaceRelationWithAction";
        var PatternCategory="Object2Concept";
        var Title="CQRS - Create handle method of event handler";
        var Name="CQRS_Relation_to_EventHandler_Handle_method";

        var FieldValues = new List<FieldValueDocument>() 
        {
            new FieldValueDocument("ConceptNode","EventHandler.Concept"),
            new FieldValueDocument("OperationNameProperty","HandleAsync"),
            new FieldValueDocument("OperationOutputProperty","Task"),
            new FieldValueDocument("OperationInputsRelation","canHandle")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();

    }


    public PatternInstanceTemplate Map_CRAC_Concept_To_CIM_Model()
    {
        Guid Id=Guid.Parse("1c3cab9a-1933-b941-80c9-69235a3ddfa2");
        Guid PatternId=MapInstance.PatternId;
        var PatternName="MapInstance";
        var PatternCategory="Object2Object";
        var Title="Map CRAC concept to CIM model";
        var Name="Map_CRAC_to_CIM";
        var FieldValues = new List<FieldValueDocument>(); 
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Map_DomainConcept_Responsibility_to_the_command_dispatch_by_controller()
    {
        Guid Id=Guid.Parse("1722cbd1-fd15-1e4b-944e-be01bd2bbb99");
        Guid PatternId=MapRelatedObjects.PatternId;
        var PatternName="MapRelatedObjects";
        var PatternCategory="Object2Object";
        var Title="Map DomainConcept Responsibility to the command dispatch by controller";
        var Name="Map_Responsibility_to_Command_dispatched_by_Controller";
        var FieldValues = new List<FieldValueDocument>() 
        {
            new FieldValueDocument("InputSource","DomainConcept.Concept"),
            new FieldValueDocument("InputDestination","Command.Concept"),
            new FieldValueDocument("InputSourceToDestinationRelation","isResponsibleFor"),
            new FieldValueDocument("OutputSource","ApiController.Concept"),
            new FieldValueDocument("OutputDestination","Command.Concept"),
            new FieldValueDocument("OutputSourceToDestinationRelation","dispatchCommand"),
            new FieldValueDocument("OutputSourceInstanceExpression","InputSource.Name+Controller"),
            new FieldValueDocument("OutputDestinationInstanceExpression","InputDestination.Name")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Map_PIM_Controller_to_PSM_Controller()
    {
        Guid Id=Guid.Parse("27bbc4f1-5f61-e446-b8f1-836c77322f01");
        Guid PatternId=MapOneToOneWithProperties.PatternId;
        var PatternName="MapOneToOneWithProperties";
        var PatternCategory="Object2Object";
        var Title="Map PIM Controller to PSM Controller";
        var Name="PIM_to_PSM_Controller_Mapping";

        var valueExpressions = new List<MemberValueExpression>(){
            new (){Name="Namespace",ValueExpression="OnlineShop.Controllers"},
            new (){Name="IsAbstract",ValueExpression="false"},
            new (){Name="Visibility",ValueExpression="public"},
            new (){Name="IsStatic",ValueExpression="false"},
            new (){Name="Extend",ValueExpression="ControllerBase"}
        };

        JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        serializerOptions.PropertyNameCaseInsensitive = true;
        var jsonValueExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(valueExpressions,serializerOptions);

        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("Source","ApiController.Concept"),
            new ("Destination","BaseClass.Concept"),
            new ("MappingExpressions",jsonValueExpression)
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();

    }

    public PatternInstanceTemplate Map_PIM_CQRS_to_PSM_CQRS_CommandHandler()
    {
        Guid Id=Guid.Parse("407d21b6-533b-9645-99b6-764dd63d2748");
        Guid PatternId=MapOneToOneWithProperties.PatternId;
        var PatternName="MapOneToOneWithProperties";
        var PatternCategory="Object2Object";
        var Title="Map PIM CQRS to PSM CQRS - CommandHandler";
        var Name="PIM_to_PSM_CommandHandler_Mapping";

        var valueExpressions = new List<MemberValueExpression>()
        {
            new() {Name="Namespace",ValueExpression="OnlineShop.Commands.Handlers"},
            new() {Name="IsAbstract",ValueExpression="false"},
            new() {Name="Visibility",ValueExpression="public"},
            new() {Name="IsStatic",ValueExpression="false"},
            new() {Name="Extend",ValueExpression="ICommandHandler<+Source.canHandle(Command.Concept)+>"}
        };

        JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        serializerOptions.PropertyNameCaseInsensitive = true;
        var jsonValueExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(valueExpressions,serializerOptions);

        var FieldValues = new List<FieldValueDocument>() 
        {
            new("Source","CommandHandler.Concept"),
            new("Destination","BaseClass.Concept"),
            new("MappingExpressions",jsonValueExpression)
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Map_PIM_CQRS_to_PSM_CQRS_Commands()
    {
        Guid Id=Guid.Parse("abfa73a2-02aa-c249-8818-499012c0cadf");
        Guid PatternId=MapOneToOneWithProperties.PatternId;
        var PatternName="MapOneToOneWithProperties";
        var PatternCategory="Object2Object";
        var Title="Map PIM CQRS to PSM CQRS - Commands";
        var Name="PIM_to_PSM_Command_Mapping";

        var valueExpressions = new List<MemberValueExpression>()
        {
            new() {Name="Namespace",ValueExpression="OnlineShop.Commands"},
            new() {Name="IsAbstract",ValueExpression="false"},
            new() {Name="Visibility",ValueExpression="public"},
            new() {Name="IsStatic",ValueExpression="false"},
            new() {Name="Extend",ValueExpression="ICommand"}
        };

        JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        serializerOptions.PropertyNameCaseInsensitive = true;
        var jsonValueExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(valueExpressions,serializerOptions);

        var FieldValues = new List<FieldValueDocument>() 
        {
            new("Source","Command.Concept"),
            new("Destination","BaseClass.Concept"),
            new("MappingExpressions",jsonValueExpression)
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public List<PatternInstanceTemplate> List()
    {
        var templates = new List<PatternInstanceTemplate>();
        templates.Add(Convert_Controller_Endpoint_to_the_Operation_and_Attributes());
        templates.Add(Convert_CRAC_model_to_CQRS_CommandHandler());
        templates.Add(Convert_CRAC_model_to_CQRS_EventHandler());
        templates.Add(Convert_CRAC_Responsibility_To_Domain_Concept_Operation());
        templates.Add(Convert_Dispatched_Command_to_the_Controller_Endpoint());
        templates.Add(Create_command_handler_constructor_In_CQRS_Model());
        templates.Add(Create_Event_handler_constructor_In_CQRS_Model());
        templates.Add(Create_handle_method_of_command_handler_In_CQRS_Model());
        templates.Add(Create_handle_method_of_Event_handler_In_CQRS_Model());
        templates.Add(Map_CRAC_Concept_To_CIM_Model());
        templates.Add(Map_DomainConcept_Responsibility_to_the_command_dispatch_by_controller());
        templates.Add(Map_PIM_Controller_to_PSM_Controller());
        templates.Add(Map_PIM_CQRS_to_PSM_CQRS_CommandHandler());
        templates.Add(Map_PIM_CQRS_to_PSM_CQRS_Commands());
        templates.Add(Map_PIM_CQRS_to_PSM_CQRS_Event());
        templates.Add(Map_PIM_CQRS_to_PSM_CQRS_EventHandler());
        templates.Add(Map_PIM_Services_to_PSM_Services());
        templates.Add(Map_PIM_Repositories_to_PSM_Repositories());
        templates.Add(Map_PIM_Core_Domain_to_PSM_Core_Domain());
	    templates.Add(Map_PIM_Interfaces_to_PSM_Interfaces());
        templates.Add(Merge_CIM_Concepts_With_PIM_Core_Domain());
        templates.Add(Merge_PIM_and_PSM_Models());
        templates.Add(Replace_Associations_With_Relation());
        templates.Add(Replace_CIM_model_Relation_with_Property());
        templates.Add(Replace_CQRS_Command_Relation_with_Property());
        templates.Add(Replace_CQRS_Event_Relation_with_Property());
        templates.Add(Replace_usePackage_relation_with_using_attribute());

        templates.Add(Map_Commands_to_Files_In_Specific_Folder());
        templates.Add(Map_Events_to_Files_In_Specific_Folder());
        templates.Add(Map_CommandHandlers_to_Files_In_Specific_Folder());
        templates.Add(Map_EventHandlers_to_Files_In_Specific_Folder());
        templates.Add(Map_Repositories_to_Files_In_Specific_Folder());
        templates.Add(Map_Services_to_Files_In_Specific_Folder());
        templates.Add(Map_Controllers_to_Files_In_Specific_Folder());
        templates.Add(Map_Entities_to_Files_In_Specific_Folder());
	    templates.Add(Map_Interfaces_to_Files_In_Specific_Folder());

        templates.Add(Extract_Operation_From_One_to_One_to_Many_Relation());
        templates.Add(Extract_Operation_Attribute_From_Chain_Of_Node());

        templates.Add(Set_Relational_Dimension_Between_File_and_Class_Concept());
	    templates.Add(Set_Relational_Dimension_Between_File_and_Interface_Concept());

        templates.Add(Create_Project_Source_File());
        templates.Add(Generate_CSharp_Code_Of_Class_Concept());
	    templates.Add(Generate_Csharp_Code_Of_Interface_Concept());
        templates.Add(Merge_Two_DomainObject_Models());

        templates.Add(Map_Interface_Property_To_Concept_Attribute());
        templates.Add(Extract_Interface_Operation_From_One_to_One_to_Many_Relation());

        templates.Add(Set_Relational_Dimension_Between_PSM_and_PIM_Controller_Model());
        templates.Add(Set_Relational_Dimension_Between_PSM_and_PIM_Core_Domain_Model());
        templates.Add(Set_Relational_Dimension_Between_PSM_and_PIM_CQRS_Model());

        templates.Add(Set_relationalDimension_Between_PIM_Entities_and_CIM_Domain_Concept());
        templates.Add(Map_CIM_Domain_Concept_to_PIM_Entities());

        return templates;

    }

    public PatternInstanceTemplate Map_PIM_CQRS_to_PSM_CQRS_Event()
    {
        Guid Id=Guid.Parse("e601dbee-fd7f-2647-8467-7578ef8de84a");
        Guid PatternId=MapOneToOneWithProperties.PatternId;
        var PatternName="MapOneToOneWithProperties";
        var PatternCategory="Object2Object";
        var Title="Map PIM CQRS to PSM CQRS - Events";
        var Name="PIM_to_PSM_Event_Mapping";

        var valueExpressions = new List<MemberValueExpression>()
        {
            new() {Name="Namespace",ValueExpression="OnlineShop.Events"},
            new() {Name="IsAbstract",ValueExpression="false"},
            new() {Name="Visibility",ValueExpression="public"},
            new() {Name="IsStatic",ValueExpression="false"},
            new() {Name="Extend",ValueExpression="IEvent"}
        };

        JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        serializerOptions.PropertyNameCaseInsensitive = true;
        var jsonValueExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(valueExpressions,serializerOptions);

        var FieldValues = new List<FieldValueDocument>() 
        {
            new("Source","Event.Concept"),
            new("Destination","BaseClass.Concept"),
            new("MappingExpressions",jsonValueExpression)
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Map_PIM_CQRS_to_PSM_CQRS_EventHandler()
    {
        Guid Id=Guid.Parse("949f64fa-79df-b445-a238-552a78b74ab5");
        Guid PatternId=MapOneToOneWithProperties.PatternId;
        var PatternName="MapOneToOneWithProperties";
        var PatternCategory="Object2Object";
        var Title="Map PIM CQRS to PSM CQRS - EventHandler";
        var Name="PIM_to_PSM_EventHandler_Mapping";

        var valueExpressions = new List<MemberValueExpression>()
        {
            new() {Name="Namespace",ValueExpression="OnlineShop.Events.Handlers"},
            new() {Name="IsAbstract",ValueExpression="false"},
            new() {Name="Visibility",ValueExpression="public"},
            new() {Name="IsStatic",ValueExpression="false"},
            new() {Name="Extend",ValueExpression="IEventHandler<+Source.canHandle(Event.Concept)+>"}
        };

        JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        serializerOptions.PropertyNameCaseInsensitive = true;
        var jsonValueExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(valueExpressions,serializerOptions);

        var FieldValues = new List<FieldValueDocument>() 
        {
            new("Source","EventHandler.Concept"),
            new("Destination","BaseClass.Concept"),
            new("MappingExpressions",jsonValueExpression)
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }
    public PatternInstanceTemplate Map_PIM_Interfaces_to_PSM_Interfaces()
    {
        Guid Id=Guid.Parse("5a42e641-b014-4458-bd34-0c47918861ea");
        Guid PatternId=MapOneToOneWithProperties.PatternId;
        var PatternName="MapOneToOneWithProperties";
        var PatternCategory="Object2Object";
        var Title="Map PIM Interfaces To PSM Interfaces";
        var Name="PIM_to_PSM_Interface_Mapping";

        var valueExpressions = new List<MemberValueExpression>()
        {
            new() {Name="Namespace",ValueExpression="OnlineShop.Interfaces"},
            new() {Name="IsAbstract",ValueExpression="false"},
            new() {Name="Visibility",ValueExpression="public"},
            new() {Name="IsStatic",ValueExpression="false"},
            new() {Name="Extend",ValueExpression=""}
        };

        JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        serializerOptions.PropertyNameCaseInsensitive = true;
        var jsonValueExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(valueExpressions,serializerOptions);

        var FieldValues = new List<FieldValueDocument>() 
        {
            new("Source","Interface.Concept"),
            new("Destination","Interface.Concept"),
            new("MappingExpressions",jsonValueExpression)
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }
    public PatternInstanceTemplate Map_PIM_Services_to_PSM_Services()
    {
        Guid Id=Guid.Parse("bd73a442-b059-4c74-9572-3076c4038d14");
        Guid PatternId=MapOneToOneWithProperties.PatternId;
        var PatternName="MapOneToOneWithProperties";
        var PatternCategory="Object2Object";
        var Title="Map PIM Services To PSM Services";
        var Name="PIM_to_PSM_Service_Mapping";

        var valueExpressions = new List<MemberValueExpression>()
        {
            new() {Name="Namespace",ValueExpression="OnlineShop.Services"},
            new() {Name="IsAbstract",ValueExpression="false"},
            new() {Name="Visibility",ValueExpression="public"},
            new() {Name="IsStatic",ValueExpression="false"},
            new() {Name="Extend",ValueExpression=""}
        };

        JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        serializerOptions.PropertyNameCaseInsensitive = true;
        var jsonValueExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(valueExpressions,serializerOptions);

        var FieldValues = new List<FieldValueDocument>() 
        {
            new("Source","Service.Concept"),
            new("Destination","BaseClass.Concept"),
            new("MappingExpressions",jsonValueExpression)
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Map_PIM_Repositories_to_PSM_Repositories()
    {
        Guid Id=Guid.Parse("c6a2d931-fbf7-4669-8fac-a22775b75802");
        Guid PatternId=MapOneToOneWithProperties.PatternId;
        var PatternName="MapOneToOneWithProperties";
        var PatternCategory="Object2Object";
        var Title="Map PIM Repositories To PSM Repositories";
        var Name="PIM_to_PSM_Repository_Mapping";

        var valueExpressions = new List<MemberValueExpression>()
        {
            new() {Name="Namespace",ValueExpression="OnlineShop.Repositories"},
            new() {Name="IsAbstract",ValueExpression="false"},
            new() {Name="Visibility",ValueExpression="public"},
            new() {Name="IsStatic",ValueExpression="false"},
            new() {Name="Extend",ValueExpression="I+Source.Name"}
        };

        JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        serializerOptions.PropertyNameCaseInsensitive = true;
        var jsonValueExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(valueExpressions,serializerOptions);

        var FieldValues = new List<FieldValueDocument>() 
        {
            new("Source","Repository.Concept"),
            new("Destination","BaseClass.Concept"),
            new("MappingExpressions",jsonValueExpression)
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Merge_CIM_Concepts_With_PIM_Core_Domain()
    {
        Guid Id=Guid.Parse("c0d5d92c-9354-2a4e-9478-ab310c44705e");
        Guid PatternId=MergeUpstreamNodePropertyWithDownStreamNodeRelation.PatternId;
        var PatternName="MergeUpstreamNodePropertyWithDownStreamNodeRelation";
        var PatternCategory="RelationalDimension";
        var Title="Merge CIM Concepts With PIM Core Domain";
        var Name="Merge_CIM_With_PIM_Core_Domain";

        var FieldValues = new List<FieldValueDocument>() 
        {
            new("SourceNode","BaseEntity.Concept"),
            new("SourceToDestinationRelationalDimension","represent"),
            new("SourceNodeRelationName","hasProperty")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Downstream Model :","DownStreamModel",FieldType.InputModel),
            new FieldDocument("Upstream Model :","UpStreamModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }


    public PatternInstanceTemplate Replace_Associations_With_Relation()
    {
        Guid Id=Guid.Parse("3f5fc54d-a808-6c4d-a280-fedf9cbcf388");
        var PatternId=ReplaceAssociationWithRelation.PatternId;
        var PatternName="ReplaceAssociationWithRelation";
        var PatternCategory="Object2Concept";
        var Title="Replace Order associations to relation";
        var Name="Order_Association_to_Relation";
        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("SourceNode","DomainConcept.Concept"),
            new ("DestinationNode","Relation.Concept"),
            new ("SourceToDestinationRelation","hasRelation"),
            new ("RelationNameProperty","RelationName"),
            new ("RelationTargetProperty","RelationTarget"),
            new ("MultiplicityProperty","Multiplicity")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Replace_CIM_model_Relation_with_Property()
    {
        Guid Id=Guid.Parse("60cd0182-6ad2-2b43-be1f-c27a92354dcf");
        Guid PatternId=ReplaceRelationWithProperty.PatternId;
        var PatternName="ReplaceRelationWithProperty";
        var PatternCategory="Object2Concept";
        var Title="Replace Order CIM model Relation with Property";
        var Name="CIM_Order_Relation_to_Property";
        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("SourceNode","DomainConcept.Concept"),
            new ("SourceToDestinationRelation","hasProperty")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();

    }

    public PatternInstanceTemplate Replace_CQRS_Command_Relation_with_Property()
    {
        Guid Id=Guid.Parse("4a89ba4d-e02a-9a44-872d-0c8192efcfef");
        Guid PatternId=ReplaceRelationWithProperty.PatternId;
        var PatternName="ReplaceRelationWithProperty";
        var PatternCategory="Object2Concept";
        var Title="Replace CQRS Command Relation with Property";
        var Name="CQRS_Command_Relation_to_Property";

        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("SourceNode","Command.Concept"),
            new ("SourceToDestinationRelation","hasProperty")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Replace_CQRS_Event_Relation_with_Property()
    {
        Guid Id=Guid.Parse("6fdce271-4585-6f40-9c3e-7ac0f003d090");
        Guid PatternId=ReplaceRelationWithProperty.PatternId;
        var PatternName="ReplaceRelationWithProperty";
        var PatternCategory="Object2Concept";
        var Title="Replace CQRS Event Relation with Property";
        var Name="CQRS_Event_Relation_to_Property";
        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("SourceNode","Event.Concept"),
            new ("SourceToDestinationRelation","hasProperty")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();

    }


    public PatternInstanceTemplate Replace_usePackage_relation_with_using_attribute()
    {
        Guid Id=Guid.Parse("57630254-4d5a-498b-8b2d-8b6ce1a99f98");
        Guid PatternId=ReplaceRelationWithConceptAttribute.PatternId;
        var PatternName="ReplaceRelationWithConceptAttribute";
        var PatternCategory="Object2Concept";
        var Title="Replace UsePackage Relation With Using Attribute";
        var Name="Replace_UsePackage_Relation_With_Using_Attribute";

        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("SourceNode","BaseClass.Concept"),
            new ("DestinationNode","Package.Concept"),
            new ("SourceToDestinationRelation","usePackage"),
            new ("AttributeNameExpression","using"),
            new ("AttributeValueExpression","DestinationNode.PackageName")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }


    private PatternInstanceTemplate? DeserializePatternInstanceTemplate(string json){
        JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        serializerOptions.PropertyNameCaseInsensitive = true;
        try{
            var instanceTemplate = JsonSerializer.Deserialize<PatternInstanceTemplateDocument>(json, serializerOptions);
            if(Equals(instanceTemplate,null))
                return null;

            return instanceTemplate.ToPatternInstanceTemplate();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
        


    }

    public PatternInstanceTemplate Map_Commands_to_Files_In_Specific_Folder()
    {
        Guid Id=Guid.Parse("57ad25c9-b911-4c9c-9038-1e4f86ce697e");
        Guid PatternId=MapOneToTwo.PatternId;
        var PatternName="MapOneToTwo";
        var PatternCategory="Object2Object";
        var Title="Map Commands To Files In Specific Folder";
        var Name="Map_Commands_to_Files";

        var firstDestinationMappingExpression = new List<MemberValueExpression>()
        {
            new() {Name="FolderName",ValueExpression="Commands"},
            new() {Name="RelativePath",ValueExpression="./"}
        };

        var secondDestinationMappingExpression = new List<MemberValueExpression>(){
            new() {Name="FileName",ValueExpression="Source.Name"},
            new() {Name="Extension",ValueExpression="cs"},
            new() {Name="RelativePath",ValueExpression="./Commands"}
        };

        JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        serializerOptions.PropertyNameCaseInsensitive = true;

        var jsonFirstDestinationMappingExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(firstDestinationMappingExpression,serializerOptions);
        var jsonSecondDestinationMappingExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(secondDestinationMappingExpression,serializerOptions);

        var FieldValues = new List<FieldValueDocument>() 
        {
            new("Source","Command.Concept"),
            new("FirstDestination","ProjectFolder.Concept"),
            new("SecondDestination","ProjectFile.Concept"),
            new("FirstToSecondRelationName","hasFile"),
            new("FirstDestinationInstanceNameExpression","Commands"),
            new("FirstDestinationMappingExpression",jsonFirstDestinationMappingExpression),
            new("SecondDestinationInstanceNameExpression","Source.Name"),
            new("SecondDestinationMappingExpression",jsonSecondDestinationMappingExpression)
        };

        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Map_Events_to_Files_In_Specific_Folder()
    {
        Guid Id=Guid.Parse("3ff96930-091f-47ce-bf77-a56012069d74");
        Guid PatternId=MapOneToTwo.PatternId;
        var PatternName="MapOneToTwo";
        var PatternCategory="Object2Object";
        var Title="Map Events To Files In Specific Folder";
        var Name="Map_Events_to_Files";

        var firstDestinationMappingExpression = new List<MemberValueExpression>()
        {
            new() {Name="FolderName",ValueExpression="Events"},
            new() {Name="RelativePath",ValueExpression="./"}
        };

        var secondDestinationMappingExpression = new List<MemberValueExpression>(){
            new() {Name="FileName",ValueExpression="Source.Name"},
            new() {Name="Extension",ValueExpression="cs"},
            new() {Name="RelativePath",ValueExpression="./Events"}
        };

        JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        serializerOptions.PropertyNameCaseInsensitive = true;

        var jsonFirstDestinationMappingExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(firstDestinationMappingExpression,serializerOptions);
        var jsonSecondDestinationMappingExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(secondDestinationMappingExpression,serializerOptions);

        var FieldValues = new List<FieldValueDocument>() 
        {
            new("Source","Event.Concept"),
            new("FirstDestination","ProjectFolder.Concept"),
            new("SecondDestination","ProjectFile.Concept"),
            new("FirstToSecondRelationName","hasFile"),
            new("FirstDestinationInstanceNameExpression","Events"),
            new("FirstDestinationMappingExpression",jsonFirstDestinationMappingExpression),
            new("SecondDestinationInstanceNameExpression","Source.Name"),
            new("SecondDestinationMappingExpression",jsonSecondDestinationMappingExpression)
        };

        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }
    public PatternInstanceTemplate Map_Repositories_to_Files_In_Specific_Folder()
    {
        Guid Id=Guid.Parse("a77beb7c-9281-46b8-9899-354cc7f99c8e");
        Guid PatternId=MapOneToTwo.PatternId;
        var PatternName="MapOneToTwo";
        var PatternCategory="Object2Object";
        var Title="Map Repositories To Files In Specific Folder";
        var Name="Map_Repositories_to_Files";

        var firstDestinationMappingExpression = new List<MemberValueExpression>()
        {
            new() {Name="FolderName",ValueExpression="Repositories"},
            new() {Name="RelativePath",ValueExpression="./"}
        };

        var secondDestinationMappingExpression = new List<MemberValueExpression>(){
            new() {Name="FileName",ValueExpression="Source.Name"},
            new() {Name="Extension",ValueExpression="cs"},
            new() {Name="RelativePath",ValueExpression="./Repositories"}
        };

        JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        serializerOptions.PropertyNameCaseInsensitive = true;

        var jsonFirstDestinationMappingExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(firstDestinationMappingExpression,serializerOptions);
        var jsonSecondDestinationMappingExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(secondDestinationMappingExpression,serializerOptions);

        var FieldValues = new List<FieldValueDocument>() 
        {
            new("Source","Repository.Concept"),
            new("FirstDestination","ProjectFolder.Concept"),
            new("SecondDestination","ProjectFile.Concept"),
            new("FirstToSecondRelationName","hasFile"),
            new("FirstDestinationInstanceNameExpression","Repositories"),
            new("FirstDestinationMappingExpression",jsonFirstDestinationMappingExpression),
            new("SecondDestinationInstanceNameExpression","Source.Name"),
            new("SecondDestinationMappingExpression",jsonSecondDestinationMappingExpression)
        };

        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }
    public PatternInstanceTemplate Map_Services_to_Files_In_Specific_Folder()
    {
        Guid Id=Guid.Parse("4e27c03f-40fc-486b-87f5-8bda2c059444");
        Guid PatternId=MapOneToTwo.PatternId;
        var PatternName="MapOneToTwo";
        var PatternCategory="Object2Object";
        var Title="Map Services To Files In Specific Folder";
        var Name="Map_Services_to_Files";

        var firstDestinationMappingExpression = new List<MemberValueExpression>()
        {
            new() {Name="FolderName",ValueExpression="Services"},
            new() {Name="RelativePath",ValueExpression="./"}
        };

        var secondDestinationMappingExpression = new List<MemberValueExpression>(){
            new() {Name="FileName",ValueExpression="Source.Name"},
            new() {Name="Extension",ValueExpression="cs"},
            new() {Name="RelativePath",ValueExpression="./Services"}
        };

        JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        serializerOptions.PropertyNameCaseInsensitive = true;

        var jsonFirstDestinationMappingExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(firstDestinationMappingExpression,serializerOptions);
        var jsonSecondDestinationMappingExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(secondDestinationMappingExpression,serializerOptions);

        var FieldValues = new List<FieldValueDocument>() 
        {
            new("Source","Service.Concept"),
            new("FirstDestination","ProjectFolder.Concept"),
            new("SecondDestination","ProjectFile.Concept"),
            new("FirstToSecondRelationName","hasFile"),
            new("FirstDestinationInstanceNameExpression","Services"),
            new("FirstDestinationMappingExpression",jsonFirstDestinationMappingExpression),
            new("SecondDestinationInstanceNameExpression","Source.Name"),
            new("SecondDestinationMappingExpression",jsonSecondDestinationMappingExpression)
        };

        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Map_CommandHandlers_to_Files_In_Specific_Folder()
    {
        Guid Id=Guid.Parse("8d4ad8a9-892d-4994-adf8-5ea24b0fb900");
        Guid PatternId=MapOneToTwo.PatternId;
        var PatternName="MapOneToTwo";
        var PatternCategory="Object2Object";
        var Title="Map CommandHandlers To Files In Specific Folder";
        var Name="Map_CommandHandlers_to_Files";

        var firstDestinationMappingExpression = new List<MemberValueExpression>()
        {
            new() {Name="FolderName",ValueExpression="Handlers"},
            new() {Name="RelativePath",ValueExpression="./Commands"}
        };

        var secondDestinationMappingExpression = new List<MemberValueExpression>(){
            new() {Name="FileName",ValueExpression="Source.Name"},
            new() {Name="Extension",ValueExpression="cs"},
            new() {Name="RelativePath",ValueExpression="./Commands/Handlers"}
        };

        JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        serializerOptions.PropertyNameCaseInsensitive = true;

        var jsonFirstDestinationMappingExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(firstDestinationMappingExpression,serializerOptions);
        var jsonSecondDestinationMappingExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(secondDestinationMappingExpression,serializerOptions);

        var FieldValues = new List<FieldValueDocument>() 
        {
            new("Source","CommandHandler.Concept"),
            new("FirstDestination","ProjectFolder.Concept"),
            new("SecondDestination","ProjectFile.Concept"),
            new("FirstToSecondRelationName","hasFile"),
            new("FirstDestinationInstanceNameExpression","CommandHandlers"),
            new("FirstDestinationMappingExpression",jsonFirstDestinationMappingExpression),
            new("SecondDestinationInstanceNameExpression","Source.Name"),
            new("SecondDestinationMappingExpression",jsonSecondDestinationMappingExpression)
        };

        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Map_EventHandlers_to_Files_In_Specific_Folder()
    {
        Guid Id=Guid.Parse("38eec3fa-791d-4bc8-a589-04a9c56077ec");
        Guid PatternId=MapOneToTwo.PatternId;
        var PatternName="MapOneToTwo";
        var PatternCategory="Object2Object";
        var Title="Map EventHandlers To Files In Specific Folder";
        var Name="Map_EventHandlers_to_Files";

        var firstDestinationMappingExpression = new List<MemberValueExpression>()
        {
            new() {Name="FolderName",ValueExpression="Handlers"},
            new() {Name="RelativePath",ValueExpression="./Events"}
        };

        var secondDestinationMappingExpression = new List<MemberValueExpression>(){
            new() {Name="FileName",ValueExpression="Source.Name"},
            new() {Name="Extension",ValueExpression="cs"},
            new() {Name="RelativePath",ValueExpression="./Events/Handlers"}
        };

        JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        serializerOptions.PropertyNameCaseInsensitive = true;

        var jsonFirstDestinationMappingExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(firstDestinationMappingExpression,serializerOptions);
        var jsonSecondDestinationMappingExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(secondDestinationMappingExpression,serializerOptions);

        var FieldValues = new List<FieldValueDocument>() 
        {
            new("Source","EventHandler.Concept"),
            new("FirstDestination","ProjectFolder.Concept"),
            new("SecondDestination","ProjectFile.Concept"),
            new("FirstToSecondRelationName","hasFile"),
            new("FirstDestinationInstanceNameExpression","EventHandlers"),
            new("FirstDestinationMappingExpression",jsonFirstDestinationMappingExpression),
            new("SecondDestinationInstanceNameExpression","Source.Name"),
            new("SecondDestinationMappingExpression",jsonSecondDestinationMappingExpression)
        };

        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Map_Controllers_to_Files_In_Specific_Folder()
    {
        Guid Id=Guid.Parse("a6e75c70-0726-4583-b2f5-18e6ff09094e");
        Guid PatternId=MapOneToTwo.PatternId;
        var PatternName="MapOneToTwo";
        var PatternCategory="Object2Object";
        var Title="Map Controllers To Files In Specific Folder";
        var Name="Map_Controllers_to_Files";

        var firstDestinationMappingExpression = new List<MemberValueExpression>()
        {
            new() {Name="FolderName",ValueExpression="Controllers"},
            new() {Name="RelativePath",ValueExpression="./"}
        };

        var secondDestinationMappingExpression = new List<MemberValueExpression>(){
            new() {Name="FileName",ValueExpression="Source.Name"},
            new() {Name="Extension",ValueExpression="cs"},
            new() {Name="RelativePath",ValueExpression="./Controllers"}
        };

        JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        serializerOptions.PropertyNameCaseInsensitive = true;

        var jsonFirstDestinationMappingExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(firstDestinationMappingExpression,serializerOptions);
        var jsonSecondDestinationMappingExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(secondDestinationMappingExpression,serializerOptions);

        var FieldValues = new List<FieldValueDocument>() 
        {
            new("Source","ApiController.Concept"),
            new("FirstDestination","ProjectFolder.Concept"),
            new("SecondDestination","ProjectFile.Concept"),
            new("FirstToSecondRelationName","hasFile"),
            new("FirstDestinationInstanceNameExpression","Controllers"),
            new("FirstDestinationMappingExpression",jsonFirstDestinationMappingExpression),
            new("SecondDestinationInstanceNameExpression","Source.Name"),
            new("SecondDestinationMappingExpression",jsonSecondDestinationMappingExpression)
        };

        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Set_Relational_Dimension_Between_File_and_Class_Concept()
    {
        Guid Id=Guid.Parse("9d99fa4b-1cb5-455b-b206-1ffa88aff3f7");
        Guid PatternId=SetRelationalDimension.PatternId;
        var PatternName="SetRelationalDimension";
        var PatternCategory="Object2Object";
        var Title="Set Relational Dimension Between File and Class Concept";
        var Name="Set_Relational_Dimension_Between_File_and_Class_Concept";

        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("Element","ProjectFile.Concept"),
            new ("RelationNameExpression","represent"),
            new ("RelationTargetExpression","Element.Name+.BaseClass.Concept"),
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }
    public PatternInstanceTemplate Set_Relational_Dimension_Between_File_and_Interface_Concept()
    {
        Guid Id=Guid.Parse("deda2bf3-f302-43e5-8409-5e14f7fadf9b");
        Guid PatternId=SetRelationalDimension.PatternId;
        var PatternName="SetRelationalDimension";
        var PatternCategory="Object2Object";
        var Title="Set Relational Dimension Between File and Interface Concept";
        var Name="Set_Relational_Dimension_Between_File_and_Interface_Concept";

        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("Element","ProjectFile.Concept"),
            new ("RelationNameExpression","represent"),
            new ("RelationTargetExpression","Element.Name+.Interface.Concept"),
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Generate_CSharp_Code_Of_Class_Concept()
    {
        Guid Id=Guid.Parse("f638d6de-2d79-454c-944f-a20dbdd9e24c");
        Guid PatternId=GenerateCSharpCodeOfClassConcept.PatternId;
        var PatternName="GenerateCSharpCodeOfClassConcept";
        var PatternCategory="RelationalDimension";
        var Title="Generate C# Code of Class Concept";
        var Name=" Generate_CSharp_Code_Of_Class_Concept";

        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("DownstreamNodet","ProjectFile.Concept"),
            new ("RelationalDimension","represent"),
            new ("ContentProperty","Content"),
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Downstream Model :","DownstreamModel",FieldType.InputModel),
            new FieldDocument("Upstream Model :","UpstreamModel",FieldType.InputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Map_PIM_Core_Domain_to_PSM_Core_Domain()
    {
        Guid Id=Guid.Parse("16d9cde3-93e1-4df0-a92d-95672a143c98");
        Guid PatternId=MapOneToOneWithProperties.PatternId;
        var PatternName="MapOneToOneWithProperties";
        var PatternCategory="Object2Object";
        var Title="Map PIM Core Domain Model to PSM Core Domain Model";
        var Name="PIM_to_PSM_Core_Domain_Mapping";

        var valueExpressions = new List<MemberValueExpression>(){
            new (){Name="Namespace",ValueExpression="OnlineShop.Entities"},
            new (){Name="IsAbstract",ValueExpression="false"},
            new (){Name="Visibility",ValueExpression="public"},
            new (){Name="IsStatic",ValueExpression="false"},
            new (){Name="Extend",ValueExpression="BaseEntity<Guid>"}
        };

        JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        serializerOptions.PropertyNameCaseInsensitive = true;
        var jsonValueExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(valueExpressions,serializerOptions);

        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("Source","BaseEntity.Concept"),
            new ("Destination","BaseClass.Concept"),
            new ("MappingExpressions",jsonValueExpression)
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Merge_PIM_and_PSM_Models()
    {
        Guid Id=Guid.Parse("af9cab97-85a9-41ce-b418-c0b853f5e914");
        Guid PatternId=MergeUpstreamNodeWithDownStreamNodePropertyAsAttribute.PatternId;
        var PatternName="MergeUpstreamNodeWithDownStreamNodePropertyAsAttribute";
        var PatternCategory="RelationalDimension";
        var Title="Merge PIM & PSM Models";
        var Name="Merge_PIM_and_PSM_Models";

        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("DownStreamNode","BaseClass.Concept"),
            new ("RelationalDimension","represent")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Downstream Model :","DownStreamModel",FieldType.InputModel),
            new FieldDocument("Upstream Model :","UpStreamModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Map_Entities_to_Files_In_Specific_Folder()
    {
        Guid Id=Guid.Parse("67c34503-af37-44b2-b123-e5f33423f897");
        Guid PatternId=MapOneToTwo.PatternId;
        var PatternName="MapOneToTwo";
        var PatternCategory="Object2Object";
        var Title="Map Entities To Files In Specific Folder";
        var Name="Map_Entities_to_Files";

        var firstDestinationMappingExpression = new List<MemberValueExpression>()
        {
            new() {Name="FolderName",ValueExpression="Entities"},
            new() {Name="RelativePath",ValueExpression="./"}
        };

        var secondDestinationMappingExpression = new List<MemberValueExpression>(){
            new() {Name="FileName",ValueExpression="Source.Name"},
            new() {Name="Extension",ValueExpression="cs"},
            new() {Name="RelativePath",ValueExpression="./Entities"}
        };

        JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        serializerOptions.PropertyNameCaseInsensitive = true;

        var jsonFirstDestinationMappingExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(firstDestinationMappingExpression,serializerOptions);
        var jsonSecondDestinationMappingExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(secondDestinationMappingExpression,serializerOptions);

        var FieldValues = new List<FieldValueDocument>() 
        {
            new("Source","BaseEntity.Concept"),
            new("FirstDestination","ProjectFolder.Concept"),
            new("SecondDestination","ProjectFile.Concept"),
            new("FirstToSecondRelationName","hasFile"),
            new("FirstDestinationInstanceNameExpression","Entities"),
            new("FirstDestinationMappingExpression",jsonFirstDestinationMappingExpression),
            new("SecondDestinationInstanceNameExpression","Source.Name"),
            new("SecondDestinationMappingExpression",jsonSecondDestinationMappingExpression)
        };

        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Map_Interfaces_to_Files_In_Specific_Folder()
    {
        Guid Id=Guid.Parse("f32b6fa6-ea56-4d3b-92e6-7bb03481d5e9");
        Guid PatternId=MapOneToTwo.PatternId;
        var PatternName="MapOneToTwo";
        var PatternCategory="Object2Object";
        var Title="Map Interfaces To Files In Specific Folder";
        var Name="Map_Interfaces_to_Files";

        var firstDestinationMappingExpression = new List<MemberValueExpression>()
        {
            new() {Name="FolderName",ValueExpression="Interfaces"},
            new() {Name="RelativePath",ValueExpression="./"}
        };

        var secondDestinationMappingExpression = new List<MemberValueExpression>(){
            new() {Name="FileName",ValueExpression="Source.Name"},
            new() {Name="Extension",ValueExpression="cs"},
            new() {Name="RelativePath",ValueExpression="./Interfaces"}
        };

        JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        serializerOptions.PropertyNameCaseInsensitive = true;

        var jsonFirstDestinationMappingExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(firstDestinationMappingExpression,serializerOptions);
        var jsonSecondDestinationMappingExpression =  JsonSerializer.Serialize<List<MemberValueExpression>>(secondDestinationMappingExpression,serializerOptions);

        var FieldValues = new List<FieldValueDocument>() 
        {
            new("Source","Interface.Concept"),
            new("FirstDestination","ProjectFolder.Concept"),
            new("SecondDestination","ProjectFile.Concept"),
            new("FirstToSecondRelationName","hasFile"),
            new("FirstDestinationInstanceNameExpression","Interfaces"),
            new("FirstDestinationMappingExpression",jsonFirstDestinationMappingExpression),
            new("SecondDestinationInstanceNameExpression","Source.Name"),
            new("SecondDestinationMappingExpression",jsonSecondDestinationMappingExpression)
        };

        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Generate_Csharp_Code_Of_Interface_Concept()
    {
        Guid Id=Guid.Parse("bdcc6109-c0a1-4f8f-bad9-240c24454447");
        Guid PatternId=GenerateCSharpCodeOfInterfaceConcept.PatternId;
        var PatternName="GenerateCSharpCodeOfInterfaceConcept";
        var PatternCategory="RelationalDimension";
        var Title="Generate C# Code of Interface Concept";
        var Name=" Generate_CSharp_Code_Of_Interface_Concept";

        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("DownstreamNodet","ProjectFile.Concept"),
            new ("RelationalDimension","represent"),
            new ("ContentProperty","Content"),
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Downstream Model :","DownstreamModel",FieldType.InputModel),
            new FieldDocument("Upstream Model :","UpstreamModel",FieldType.InputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Extract_Operation_From_One_to_One_to_Many_Relation()
    {
        Guid Id=Guid.Parse("55e79b19-18ce-4cde-9a35-94bb0c8ef31c");
        var PatternId=ExtractOperationFromOneToOneToManyRelation.PatternId;
        var PatternName="ExtractOperationFromOneToOneToManyRelation";
        var PatternCategory="Object2Concept";
        var Title="Extract Operation From One To One To Many Relation";
        var Name="Extract_Operation_From_One2One2Many_Relation";
        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("FirstNode","BaseClass.Concept"),
            new ("MiddleNode","Operation.Concept"),
            new ("LastNode","Parameter.Concept"),
            new ("FirstToMiddleNodeRelation","hasOperation"),
            new ("MiddleToLastNodeRelation","hasInput"),
            new ("OperationNameExpression","MiddleNode.OperationName"),
            new ("OperationInputNameExpression","LastNode.ParameterName"),
            new ("OperationInputTypeExpression","LastNode.ParameterType"),
            new ("OperationOutputTypeExpression","MiddleNode.OperationOutput")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Extract_Operation_Attribute_From_Chain_Of_Node()
    {
        Guid Id=Guid.Parse("7c532338-4ba9-4db5-aab0-81a57bc0f278");
        var PatternId=ExtractOperationAttributeFromChainOfNodes.PatternId;
        var PatternName="ExtractOperationAttributeFromChainOfNodes";
        var PatternCategory="Object2Concept";
        var Title="Extract Operation Attribute From Chain Of Nodes";
        var Name="Extract_Operation_Attribute_From_Chain_Of_Node";
        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("FirstNode","BaseClass.Concept"),
            new ("MiddleNode","Operation.Concept"),
            new ("LastNode","OperationBody.Concept"),
            new ("FirstToMiddleNodeRelation","hasOperation"),
            new ("MiddleToLastNodeRelation","hasBody"),
            new ("ConceptNameExpression","FirstNode.Name"),
            new ("ConceptTypeExpression","FirstNode._Type"),
            new ("OperationNameExpression","MiddleNode.Name"),
            new ("AttributeNameExpression","body"),
            new ("AttributeValueExpression","LastNode.Text")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Create_Project_Source_File()
    {
        Guid Id=Guid.Parse("f4fee52f-b484-4eb8-98ff-a5c9134905f6");
        Guid PatternId=AppendLineForEachOneToManyRelation.PatternId;
        var PatternName="AppendLineForEachOneToManyRelation";
        var PatternCategory="Object2Object";
        var Title="Create Project Source File";
        var Name="Create_Project_Source_File";

        var FieldValues = new List<FieldValueDocument>() 
        {
            new FieldValueDocument("Source","Project.Concept"),
            new FieldValueDocument("Destination","PackageReference.Concept"),
            new FieldValueDocument("SourceToDestinationRelation","hasDependency"),
            new FieldValueDocument("TemplateArchiveId","EmptyProject"),
            new FieldValueDocument("TemplateFileId","EmptyProject.csproj"),
            new FieldValueDocument("Marker","<!-- Add Your Package References  -->"),
            new FieldValueDocument("ValueExpression","<PackageReference Include=\"+Destination.PackageId+\" Version=\"+Destination.Version+\" />"),
            new FieldValueDocument("FileConcept","ProjectFile.Concept"),
            new FieldValueDocument("FileNameProeprty","FileName"),
            new FieldValueDocument("FileExtensionProperty","Extension"),
            new FieldValueDocument("FileRelativePathProeprty","RelativePath"),
            new FieldValueDocument("FileContentProperty","Content"),
            new FieldValueDocument("InstanceNameExpression","Source.Name"),
            new FieldValueDocument("FileNameValueExpression","Source.Name"),
            new FieldValueDocument("FileExtensionValue",".csproj"),
            new FieldValueDocument("FileRelativePathValue","./")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Merge_Two_DomainObject_Models()
    {
        Guid Id=Guid.Parse("fe65e69d-fcb2-4b4b-a530-03f80a9cd803");
        Guid PatternId=MergerDomainObjectModels.PatternId;
        var PatternName="MergerDomainObjectModels";
        var PatternCategory="Object2Object";
        var Title="Merge Two DomainObject Models";
        var Name="Merge_Two_DomainObject_Models";

        var FieldValues = new List<FieldValueDocument>() ;
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("First Model :","FirstModel",FieldType.InputModel),
            new FieldDocument("Second Model :","SecondModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Map_Interface_Property_To_Concept_Attribute()
    {
        Guid Id=Guid.Parse("e5388ab1-73dd-427a-a912-f7256fa64951");
        Guid PatternId=MapObjectPropertyToConceptAttribute.PatternId;
        var PatternName="MapObjectPropertyToConceptAttribute";
        var PatternCategory="Object2Concept";
        var Title="Map Interface Proerty To Concept Attribute";
        var Name="Map_Interface_Property_To_Concept_Attribute";

        var FieldValues = new List<FieldValueDocument>(){
            new FieldValueDocument("TypeOfInstance","Interface.Concept")
        } ;
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Extract_Interface_Operation_From_One_to_One_to_Many_Relation()
    {
        Guid Id=Guid.Parse("b3a340d4-0d04-4c29-bf23-7b1b32201762");
        var PatternId=ExtractOperationFromOneToOneToManyRelation.PatternId;
        var PatternName="ExtractOperationFromOneToOneToManyRelation";
        var PatternCategory="Object2Concept";
        var Title="Extract Interface Operation From One To One To Many Relation";
        var Name="Extract_Interface_Operation_From_One2One2Many_Relation";
        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("FirstNode","Interface.Concept"),
            new ("MiddleNode","Operation.Concept"),
            new ("LastNode","Parameter.Concept"),
            new ("FirstToMiddleNodeRelation","hasOperation"),
            new ("MiddleToLastNodeRelation","hasInput"),
            new ("OperationNameExpression","MiddleNode.OperationName"),
            new ("OperationInputNameExpression","LastNode.ParameterName"),
            new ("OperationInputTypeExpression","LastNode.ParameterType"),
            new ("OperationOutputTypeExpression","MiddleNode.OperationOutput")
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model :","OutputModel",FieldType.OutputModel)
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Set_Relational_Dimension_Between_PSM_and_PIM_Controller_Model()
    {
        Guid Id=Guid.Parse("737ce734-fa02-48b8-9e6f-1269a3a11543");
        Guid PatternId=SetHigherDimensionRelation.PatternId;
        var PatternName="SetHigherDimensionRelation";
        var PatternCategory="RelationalDimension";
        var Title="Set Relational Dimension Between PSM and PIM Controller";
        var Name="Set_Relational_Dimension_Between_PSM_and_PIM_Controller_Model";

        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("UpstreamConcept","ApiController.Concept"),
            new("DownstreamConcept","BaseClass.Concept"),
            new ("RelationNameExpression","represent"),
            new ("RelationTargetExpression","UpstreamConcept.Name+.+UpstreamConcept._Type"),
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Upstream Model :","UpstreamModel",FieldType.InputModel),
            new FieldDocument("Downstream Model :","DownstreamModel",FieldType.OutputModel),
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Set_Relational_Dimension_Between_PSM_and_PIM_Core_Domain_Model()
    {
        Guid Id=Guid.Parse("dd228d2a-ea82-4f13-9e83-470971ceae08");
        Guid PatternId=SetHigherDimensionRelation.PatternId;
        var PatternName="SetHigherDimensionRelation";
        var PatternCategory="RelationalDimension";
        var Title="Set Relational Dimension Between PSM and PIM Core Domain";
        var Name="Set_Relational_Dimension_Between_PSM_and_PIM_Core_Domain_Model";

        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("UpstreamConcept","BaseEntity.Concept"),
            new("DownstreamConcept","BaseClass.Concept"),
            new ("RelationNameExpression","represent"),
            new ("RelationTargetExpression","UpstreamConcept.Name+.+UpstreamConcept._Type"),
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Upstream Model :","UpstreamModel",FieldType.InputModel),
            new FieldDocument("Downstream Model :","DownstreamModel",FieldType.OutputModel),
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }
    public PatternInstanceTemplate Set_Relational_Dimension_Between_PSM_and_PIM_CQRS_Model()
    {
        Guid Id=Guid.Parse("3b055eb4-2892-4e32-97a6-f8b52404db3f");
        Guid PatternId=SetHigherDimensionRelation.PatternId;
        var PatternName="SetHigherDimensionRelation";
        var PatternCategory="RelationalDimension";
        var Title="Set Relational Dimension Between PSM and PIM CQRS Model";
        var Name="Set_Relational_Dimension_Between_PSM_and_PIM_CQRS_Model";

        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("UpstreamConcept","Command.Concept,Event.Concept,CommandHandler.Concept,EventHandler.Concept"),
            new("DownstreamConcept","BaseClass.Concept"),
            new ("RelationNameExpression","represent"),
            new ("RelationTargetExpression","UpstreamConcept.Name+.+UpstreamConcept._Type"),
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Upstream Model :","UpstreamModel",FieldType.InputModel),
            new FieldDocument("Downstream Model :","DownstreamModel",FieldType.OutputModel),
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }

    public PatternInstanceTemplate Map_CIM_Domain_Concept_to_PIM_Entities()
    {
        Guid Id=Guid.Parse("b89a8357-c235-4fdb-9ba8-551a14292a54");
        Guid PatternId=MapOneToOne.PatternId;
        var PatternName="MapOneToOne";
        var PatternCategory="Object2Object";
        var Title="Map CIM Domain Concept to PIM Entities";
        var Name="Map_CIM_Domain_Concept_to_PIM_Entities";

        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("Source","DomainConcept.Concept"),
            new("Destination","BaseEntity.Concept"),
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Input Model :","InputModel",FieldType.InputModel),
            new FieldDocument("Output Model","OutputModel",FieldType.OutputModel),
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }
    public PatternInstanceTemplate Set_relationalDimension_Between_PIM_Entities_and_CIM_Domain_Concept()
    {
        Guid Id=Guid.Parse("ea3a1a66-a875-4c05-a835-613154fe91fb");
        Guid PatternId=SetHigherDimensionRelation.PatternId;
        var PatternName="SetHigherDimensionRelation";
        var PatternCategory="RelationalDimension";
        var Title="Set Relational Dimension Between PIM Entities and CIM DomainConcept";
        var Name="Set_relationalDimension_Between_PIM_Entities_and_CIM_Domain_Concept";

        var FieldValues = new List<FieldValueDocument>() 
        {
            new ("UpstreamConcept","DomainConcept.Concept"),
            new("DownstreamConcept","BaseEntity.Concept"),
            new ("RelationNameExpression","represent"),
            new ("RelationTargetExpression","UpstreamConcept.Name+.+UpstreamConcept._Type"),
        };
        var Variables = new List<FieldDocument>()
        {
            new FieldDocument("Upstream Model :","UpstreamModel",FieldType.InputModel),
            new FieldDocument("Downstream Model :","DownstreamModel",FieldType.OutputModel),
        };
        var templateDoc = new PatternInstanceTemplateDocument(Id,PatternId,PatternName,PatternCategory,Title,Name,FieldValues,Variables);
        return templateDoc.ToPatternInstanceTemplate();
    }
}