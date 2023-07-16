import corruptionhades.injection.misc.Classes; 
import corruptionhades.utils.ReflectionHelper; 
import corruptionhades.injection.OOPWrapper; 
 
import java.lang.reflect.*; 

public class Component extends OOPWrapper { 
 
    public Component(Object instance) { 
        super(ReflectionHelper.getClass("sw"), instance); 
    } 
 

    public void getStyle() throws Exception { 
        Method method = clazz.getMethod("a"); 
        rh.invoke(method, instance); 
    } 

    public void getContents() throws Exception { 
        Method method = clazz.getMethod("b"); 
        rh.invoke(method, instance); 
    } 

    /** 
     * @return java.lang.String
    **/ 
    public java.lang.String getString() throws Exception { 
        Method method = clazz.getMethod("getString"); 
        return (java.lang.String) rh.invokeReturn(method, instance); 
    } 

    /** 
     * @param a0
     * @return java.lang.String
    **/ 
    public java.lang.String getString(int a0) throws Exception { 
        Method method = clazz.getMethod("a", int.class); 
        return (java.lang.String) rh.invokeReturn(method, instance, a0); 
    } 

    public void getSiblings() throws Exception { 
        Method method = clazz.getMethod("c"); 
        rh.invoke(method, instance); 
    } 

    /** 
     * @return Object
    **/ 
    public Object plainCopy() throws Exception { 
        Method method = clazz.getMethod("d"); 
        return rh.invokeReturn(method, instance); 
    } 

    /** 
     * @return Object
    **/ 
    public Object copy() throws Exception { 
        Method method = clazz.getMethod("e"); 
        return rh.invokeReturn(method, instance); 
    } 

    public void getVisualOrderText() throws Exception { 
        Method method = clazz.getMethod("f"); 
        rh.invoke(method, instance); 
    } 

    /** 
     * @param a0 net.minecraft.network.chat.FormattedText$StyledContentConsumer
     * @param a1 net.minecraft.network.chat.Style
     * @return Object
    **/ 
    public Object visit(Object a0, Object a1) throws Exception { 
        Method method = clazz.getMethod("a", ReflectionHelper.getClass("ta$b"), ReflectionHelper.getClass("ts")); 
        return rh.invokeReturn(method, instance, a0, a1); 
    } 

    /** 
     * @param a0 net.minecraft.network.chat.FormattedText$ContentConsumer
     * @return Object
    **/ 
    public Object visit(Object a0) throws Exception { 
        Method method = clazz.getMethod("a", ReflectionHelper.getClass("ta$a")); 
        return rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @return java.util.List
    **/ 
    public java.util.List toFlatList() throws Exception { 
        Method method = clazz.getMethod("g"); 
        return (java.util.List) rh.invokeReturn(method, instance); 
    } 

    /** 
     * @param a0 net.minecraft.network.chat.Style
     * @return java.util.List
    **/ 
    public java.util.List toFlatList(Object a0) throws Exception { 
        Method method = clazz.getMethod("a", ReflectionHelper.getClass("ts")); 
        return (java.util.List) rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @param a0 net.minecraft.network.chat.Component
     * @return boolean
    **/ 
    public boolean contains(Object a0) throws Exception { 
        Method method = clazz.getMethod("a", ReflectionHelper.getClass("sw")); 
        return (boolean) rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @param a0
     * @return Object
    **/ 
    public Object nullToEmpty(java.lang.String a0) throws Exception { 
        Method method = clazz.getMethod("a", java.lang.String.class); 
        return rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @param a0
     * @return Object
    **/ 
    public Object literal(java.lang.String a0) throws Exception { 
        Method method = clazz.getMethod("b", java.lang.String.class); 
        return rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @param a0
     * @return Object
    **/ 
    public Object translatable(java.lang.String a0) throws Exception { 
        Method method = clazz.getMethod("c", java.lang.String.class); 
        return rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @param a0
     * @param a1 java.lang.Object[]
     * @return Object
    **/ 
    public Object translatable(java.lang.String a0, java.lang.Object[] a1) throws Exception { 
        Method method = clazz.getMethod("a", java.lang.String.class, java.lang.Object[].class); 
        return rh.invokeReturn(method, instance, a0, a1); 
    } 

    /** 
     * @param a0
     * @param a1
     * @return Object
    **/ 
    public Object translatableWithFallback(java.lang.String a0, java.lang.String a1) throws Exception { 
        Method method = clazz.getMethod("a", java.lang.String.class, java.lang.String.class); 
        return rh.invokeReturn(method, instance, a0, a1); 
    } 

    /** 
     * @param a0
     * @param a1
     * @param a2 java.lang.Object[]
     * @return Object
    **/ 
    public Object translatableWithFallback(java.lang.String a0, java.lang.String a1, java.lang.Object[] a2) throws Exception { 
        Method method = clazz.getMethod("a", java.lang.String.class, java.lang.String.class, java.lang.Object[].class); 
        return rh.invokeReturn(method, instance, a0, a1, a2); 
    } 

    /** 
     * @return Object
    **/ 
    public Object empty() throws Exception { 
        Method method = clazz.getMethod("h"); 
        return rh.invokeReturn(method, instance); 
    } 

    /** 
     * @param a0
     * @return Object
    **/ 
    public Object keybind(java.lang.String a0) throws Exception { 
        Method method = clazz.getMethod("d", java.lang.String.class); 
        return rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @param a0
     * @param a1
     * @param a2 java.util.Optional
     * @param a3 net.minecraft.network.chat.contents.DataSource
     * @return Object
    **/ 
    public Object nbt(java.lang.String a0, boolean a1, Object a2, Object a3) throws Exception { 
        Method method = clazz.getMethod("a", java.lang.String.class, boolean.class, java.util.Optional.class, ReflectionHelper.getClass("tx")); 
        return rh.invokeReturn(method, instance, a0, a1, a2, a3); 
    } 

    /** 
     * @param a0
     * @param a1
     * @return Object
    **/ 
    public Object score(java.lang.String a0, java.lang.String a1) throws Exception { 
        Method method = clazz.getMethod("b", java.lang.String.class, java.lang.String.class); 
        return rh.invokeReturn(method, instance, a0, a1); 
    } 

    /** 
     * @param a0
     * @param a1 java.util.Optional
     * @return Object
    **/ 
    public Object selector(java.lang.String a0, Object a1) throws Exception { 
        Method method = clazz.getMethod("a", java.lang.String.class, java.util.Optional.class); 
        return rh.invokeReturn(method, instance, a0, a1); 
    } 

    /** 
     * @param a0
     * @param a1 net.minecraft.network.chat.Style
     * @param a2
     * @return Object
    **/ 
    public Object lambda$toFlatList$1(java.util.List a0, Object a1, java.lang.String a2) throws Exception { 
        Method method = clazz.getMethod("a", java.util.List.class, ReflectionHelper.getClass("ts"), java.lang.String.class); 
        return rh.invokeReturn(method, instance, a0, a1, a2); 
    } 

    /** 
     * @param a0
     * @param a1
     * @param a2
     * @return Object
    **/ 
    public Object lambda$getString$0(int a0, java.lang.StringBuilder a1, java.lang.String a2) throws Exception { 
        Method method = clazz.getMethod("a", int.class, java.lang.StringBuilder.class, java.lang.String.class); 
        return rh.invokeReturn(method, instance, a0, a1, a2); 
    } 
} 
