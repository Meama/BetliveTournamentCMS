namespace Application.Policy;

public static partial class ProjectPolicys
{
    public static List<string> GetProjectPermissions()
    {
        var result = new List<string>();
        var baseType = typeof(ProjectPolicys);


        var modules = baseType.GetNestedTypes();
        foreach (var module in modules)
        {
            var properties = module.GetFields().ToList();
            foreach (var property in properties)
            {
                var value = property.GetValue(properties);
                result.Add(value.ToString());
            }
        }

        return result;
    }
}

public static partial class ProjectPolicys
{
    public class IconsModule
    {
        public const string SetIcons = nameof(IconsModule) + "_" + nameof(SetIcons);
    }
}

public static partial class ProjectPolicys
{
    public class TimerModule
    {
        public const string SetCountdown = nameof(TimerModule) + "_" + nameof(SetCountdown);
    }
}
public static partial class ProjectPolicys
{
    public class TurnamentResultModule
    {
        public const string Add = nameof(TurnamentResultModule) + "_" + nameof(Add);
        public const string Edit = nameof(TurnamentResultModule) + "_" + nameof(Edit);
        public const string AddList = nameof(TurnamentResultModule) + "_" + nameof(AddList);
        public const string DeleteAll = nameof(TurnamentResultModule) + "_" + nameof(DeleteAll);
        public const string ImportCsv = nameof(TurnamentResultModule) + "_" + nameof(ImportCsv);
        public const string DeleteTurnamentById = nameof(TurnamentResultModule) + "_" + nameof(DeleteTurnamentById);
    }
}


public static partial class ProjectPolicys
{
    public class WaitingModule
    {
        public const string SetText = nameof(WaitingModule) + "_" + nameof(SetText);
    }
}
public static partial class ProjectPolicys
{
    public class IdentityModule
    {
        public const string GetClaims = nameof(IdentityModule) + "_" + nameof(GetClaims);
        public const string DeleteRole = nameof(IdentityModule) + "_" + nameof(DeleteRole);
        public const string GetAllRoles = nameof(IdentityModule) + "_" + nameof(GetAllRoles);
        public const string Registration = nameof(IdentityModule) + "_" + nameof(Registration);
        public const string EditUserName = nameof(IdentityModule) + "_" + nameof(EditUserName);
        public const string AddRoleToUser = nameof(IdentityModule) + "_" + nameof(AddRoleToUser);
        public const string ChangePassword = nameof(IdentityModule) + "_" + nameof(ChangePassword);
        public const string AddRoleWithClaims = nameof(IdentityModule) + "_" + nameof(AddRoleWithClaims);
        public const string DeleteRoleFromUser = nameof(IdentityModule) + "_" + nameof(DeleteRoleFromUser);
    }
}