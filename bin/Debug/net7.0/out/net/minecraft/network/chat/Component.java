import corruptionhades.injection.misc.Classes; 
import corruptionhades.utils.ReflectionHelper; 
import corruptionhades.injection.OOPWrapper; 
 
import java.lang.reflect.*; 

public class Component extends OOPWrapper { 
 
    public Component(Object instance) { 
        super(ReflectionHelper.getClass("sw"), instance); 
    } 
 
    public Object getStyle()() throws Exception { 
        return rh.getField("a", instance); 
    }

    public Object getStyle()(Object getstyle()) throws Exception { 
        rh.setField("a", instance, getstyle()); 
        return getstyle(); 
    } 
 
    public Object getContents()() throws Exception { 
        return rh.getField("b", instance); 
    }

    public Object getContents()(Object getcontents()) throws Exception { 
        rh.setField("b", instance, getcontents()); 
        return getcontents(); 
    } 
 
    public java.util.List getSiblings()() throws Exception { 
        return (java.util.List) rh.getField("c", instance); 
    }

    public java.util.List getSiblings()(java.util.List getsiblings()) throws Exception { 
        rh.setField("c", instance, getsiblings()); 
        return getsiblings(); 
    } 
 
    public Object getVisualOrderText()() throws Exception { 
        return rh.getField("f", instance); 
    }

    public Object getVisualOrderText()(Object getvisualordertext()) throws Exception { 
        rh.setField("f", instance, getvisualordertext()); 
        return getvisualordertext(); 
    } 
 

    /** 
     * @return Object
    **/ 
    public Object getString() throws Exception { 
        Method method = clazz.getMethod("getString".class); 
        return rh.invokeReturn(method, instancea0); 
    } 

    /** 
     * @param int a0
     * @return Object
    **/ 
    public Object getString(int a0) throws Exception { 
        Method method = clazz.getMethod("a", int.class); 
        return rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @return Object
    **/ 
    public Object plainCopy() throws Exception { 
        Method method = clazz.getMethod("d".class); 
        return rh.invokeReturn(method, instancea0); 
    } 

    /** 
     * @return Object
    **/ 
    public Object copy() throws Exception { 
        Method method = clazz.getMethod("e".class); 
        return rh.invokeReturn(method, instancea0); 
    } 

    /** 
     * @param Object a0 net.minecraft.network.chat.FormattedText$StyledContentConsumer
     * @param Object a1 net.minecraft.network.chat.Style
     * @return Object
    **/ 
    public Object visit(Object a0, Object a1) throws Exception { 
        Method method = clazz.getMethod("a", ReflectionHelper.getClass("ta$b"), ReflectionHelper.getClass("ts")); 
        return rh.invokeReturn(method, instance, a0, a1); 
    } 

    /** 
     * @param Object a0 net.minecraft.network.chat.FormattedText$ContentConsumer
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
        Method method = clazz.getMethod("g".class); 
        return (java.util.List) rh.invokeReturn(method, instancea0); 
    } 

    /** 
     * @param Object a0 net.minecraft.network.chat.Style
     * @return java.util.List
    **/ 
    public java.util.List toFlatList(Object a0) throws Exception { 
        Method method = clazz.getMethod("a", ReflectionHelper.getClass("ts")); 
        return (java.util.List) rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @param Object a0 net.minecraft.network.chat.Component
     * @return boolean
    **/ 
    public boolean contains(Object a0) throws Exception { 
        Method method = clazz.getMethod("a", ReflectionHelper.getClass("sw")); 
        return (boolean) rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @param Object a0 java.lang.String
     * @return Object
    **/ 
    public Object nullToEmpty(Object a0) throws Exception { 
        Method method = clazz.getMethod("a", java.lang.String.class); 
        return rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @param Object a0 java.lang.String
     * @return Object
    **/ 
    public Object literal(Object a0) throws Exception { 
        Method method = clazz.getMethod("b", java.lang.String.class); 
        return rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @param Object a0 java.lang.String
     * @return Object
    **/ 
    public Object translatable(Object a0) throws Exception { 
        Method method = clazz.getMethod("c", java.lang.String.class); 
        return rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @param Object a0 java.lang.String
     * @param Object a1 java.lang.Object[]
     * @return Object
    **/ 
    public Object translatable(Object a0, Object a1) throws Exception { 
        Method method = clazz.getMethod("a", java.lang.String.class, java.lang.Object[].class); 
        return rh.invokeReturn(method, instance, a0, a1); 
    } 

    /** 
     * @param Object a0 java.lang.String
     * @param Object a1 java.lang.String
     * @return Object
    **/ 
    public Object translatableWithFallback(Object a0,Object a0) throws Exception { 
        Method method = clazz.getMethod("a", java.lang.String.classjava.lang.String.class); 
        return rh.invokeReturn(method, instance, a0a1); 
    } 

    /** 
     * @param Object a0 java.lang.String
     * @param Object a1 java.lang.String
     * @param Object a2 java.lang.Object[]
     * @return Object
    **/ 
    public Object translatableWithFallback(Object a0,Object a0, Object a2) throws Exception { 
        Method method = clazz.getMethod("a", java.lang.String.class, java.lang.String.class, java.lang.Object[].class); 
        return rh.invokeReturn(method, instance, a0, a1, a2); 
    } 

    /** 
     * @return Object
    **/ 
    public Object empty() throws Exception { 
        Method method = clazz.getMethod("h".class); 
        return rh.invokeReturn(method, instancea0); 
    } 

    /** 
     * @param Object a0 java.lang.String
     * @return Object
    **/ 
    public Object keybind(Object a0) throws Exception { 
        Method method = clazz.getMethod("d", java.lang.String.class); 
        return rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @param Object a0 java.lang.String
     * @param boolean a1
     * @param Object a2 java.util.Optional
     * @param Object a3 net.minecraft.network.chat.contents.DataSource
     * @return Object
    **/ 
    public Object nbt(Object a0, boolean a1, Object a2, Object a3) throws Exception { 
        Method method = clazz.getMethod("a", java.lang.String.class, boolean.class, java.util.Optional.class, ReflectionHelper.getClass("tx")); 
        return rh.invokeReturn(method, instance, a0, a1, a2, a3); 
    } 

    /** 
     * @param Object a0 java.lang.String
     * @param Object a1 java.lang.String
     * @return Object
    **/ 
    public Object score(Object a0,Object a0) throws Exception { 
        Method method = clazz.getMethod("b", java.lang.String.classjava.lang.String.class); 
        return rh.invokeReturn(method, instance, a0a1); 
    } 

    /** 
     * @param Object a0 java.lang.String
     * @param Object a1 java.util.Optional
     * @return Object
    **/ 
    public Object selector(Object a0, Object a1) throws Exception { 
        Method method = clazz.getMethod("a", java.lang.String.class, java.util.Optional.class); 
        return rh.invokeReturn(method, instance, a0, a1); 
    } 

    /** 
     * @param java.util.List a0
     * @param Object a1 net.minecraft.network.chat.Style
     * @param Object a2 java.lang.String
     * @return Object
    **/ 
    public Object lambda$toFlatList$1(java.util.List a0, Object a1, Object a2) throws Exception { 
        Method method = clazz.getMethod("a", java.util.List.class, ReflectionHelper.getClass("ts"), java.lang.String.class); 
        return rh.invokeReturn(method, instance, a0, a1, a2); 
    } 

    /** 
     * @param int a0
     * @param Object a1 java.lang.StringBuilder
     * @param Object a2 java.lang.String
     * @return Object
    **/ 
    public Object lambda$getString$0(int a0, Object a1, Object a2) throws Exception { 
        Method method = clazz.getMethod("a", int.class, java.lang.StringBuilder.class, java.lang.String.class); 
        return rh.invokeReturn(method, instance, a0, a1, a2); 
    } 
} 
