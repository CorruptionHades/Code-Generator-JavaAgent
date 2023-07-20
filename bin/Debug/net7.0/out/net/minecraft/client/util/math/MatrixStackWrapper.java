import corruptionhades.injection.misc.Classes; 
import corruptionhades.utils.ReflectionHelper; 
import corruptionhades.injection.OOPWrapper; 
 
import java.lang.reflect.*; 

 /* 
 * Auto generated Wrapper class 
 * using CorruptionHades' Wrapper generator 
 * @author CorruptionHades 
 */ 
 
public class MatrixStackWrapper extends OOPWrapper { 
 
    public MatrixStack(Object instance) { 
        super(ReflectionHelper.getClass("eij"), instance); 
    } 
 
    public Object stack() throws Exception { 
        return rh.getField("a", instance); 
    }

    public Object stack(Object stack) throws Exception { 
        rh.setField("a", instance, stack); 
        return stack; 
    } 
 

    /** 
     * a0
     * a1
     * a2
     */ 
    public void translate(float a0, float a1, float a2) throws Exception { 
        Method method = clazz.getMethod("a", float.class, float.class, float.class); 
        rh.invoke(method, instance, a0, a1, a2); 
    } 

    /** 
     * a0
     * a1
     * a2
     */ 
    public void scale(float a0, float a1, float a2) throws Exception { 
        Method method = clazz.getMethod("b", float.class, float.class, float.class); 
        rh.invoke(method, instance, a0, a1, a2); 
    } 

    /** 
     * a0 org.joml.Quaternionf
     */ 
    public void multiply(Object a0) throws Exception { 
        Method method = clazz.getMethod("a", ReflectionHelper.getClass("org.joml.Quaternionf")); 
        rh.invoke(method, instance, a0); 
    } 

    /** 
     * a0 org.joml.Quaternionf
     * a1
     * a2
     * a3
     */ 
    public void multiply(Object a0, float a1, float a2, float a3) throws Exception { 
        Method method = clazz.getMethod("a", ReflectionHelper.getClass("org.joml.Quaternionf"), float.class, float.class, float.class); 
        rh.invoke(method, instance, a0, a1, a2, a3); 
    } 

    /** 
     */ 
    public void push() throws Exception { 
        Method method = clazz.getMethod("a"); 
        rh.invoke(method, instance); 
    } 

    /** 
     */ 
    public void pop() throws Exception { 
        Method method = clazz.getMethod("b"); 
        rh.invoke(method, instance); 
    } 

    /** 
     * @return net.minecraft.client.util.math.MatrixStack$Entry
     */ 
    public Object peek() throws Exception { 
        Method method = clazz.getMethod("c"); 
        return rh.invokeReturn(method, instance); 
    } 

    /** 
     * @return boolean
     */ 
    public boolean isEmpty() throws Exception { 
        Method method = clazz.getMethod("d"); 
        return (boolean) rh.invokeReturn(method, instance); 
    } 

    /** 
     */ 
    public void loadIdentity() throws Exception { 
        Method method = clazz.getMethod("e"); 
        rh.invoke(method, instance); 
    } 

    /** 
     * a0 org.joml.Matrix4f
     */ 
    public void multiplyPositionMatrix(Object a0) throws Exception { 
        Method method = clazz.getMethod("a", ReflectionHelper.getClass("org.joml.Matrix4f")); 
        rh.invoke(method, instance, a0); 
    } 

    /** 
     * a0
     */ 
    public void method_22908(java.util.ArrayDeque a0) throws Exception { 
        Method method = clazz.getMethod("a", java.util.ArrayDeque.class); 
        rh.invoke(method, instance, a0); 
    } 

    /** 
     * a0
     * a1
     * a2
     */ 
    public void translate(double a0, double a1, double a2) throws Exception { 
        Method method = clazz.getMethod("a", double.class, double.class, double.class); 
        rh.invoke(method, instance, a0, a1, a2); 
    } 
} 
