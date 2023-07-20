import corruptionhades.hook.Hook; 
import corruptionhades.utils.CodeInjection; 
 
public class GameRendererHook { 
 
    public GameRendererHook { 
        super(ReflectionHelper.getClass("fjq")); 
    } 
 
    @IMethodHook(methodName = "a", location = CodeInjection.Location.BEFORE, methodParams = {"eij", "float"})
    public String tiltViewWhenHurtHook() { 
        return "{ /* Code here */ }"; 
    }
 
}