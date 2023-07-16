import corruptionhades.injection.misc.Classes; 
import corruptionhades.utils.ReflectionHelper; 
import corruptionhades.injection.OOPWrapper; 
 
import java.lang.reflect.*; 

public class CommonComponents extends OOPWrapper { 
 
    public CommonComponents(Object instance) { 
        super(ReflectionHelper.getClass("sv"), instance); 
    } 
 
    public Object EMPTY() throws Exception { 
        return rh.getField("a", instance); 
    }

    public Object EMPTY(Object empty) throws Exception { 
        rh.setField("a", instance, empty); 
        return empty; 
    } 
 
    public Object OPTION_ON() throws Exception { 
        return rh.getField("b", instance); 
    }

    public Object OPTION_ON(Object option_on) throws Exception { 
        rh.setField("b", instance, option_on); 
        return option_on; 
    } 
 
    public Object OPTION_OFF() throws Exception { 
        return rh.getField("c", instance); 
    }

    public Object OPTION_OFF(Object option_off) throws Exception { 
        rh.setField("c", instance, option_off); 
        return option_off; 
    } 
 
    public Object GUI_DONE() throws Exception { 
        return rh.getField("d", instance); 
    }

    public Object GUI_DONE(Object gui_done) throws Exception { 
        rh.setField("d", instance, gui_done); 
        return gui_done; 
    } 
 
    public Object GUI_CANCEL() throws Exception { 
        return rh.getField("e", instance); 
    }

    public Object GUI_CANCEL(Object gui_cancel) throws Exception { 
        rh.setField("e", instance, gui_cancel); 
        return gui_cancel; 
    } 
 
    public Object GUI_YES() throws Exception { 
        return rh.getField("f", instance); 
    }

    public Object GUI_YES(Object gui_yes) throws Exception { 
        rh.setField("f", instance, gui_yes); 
        return gui_yes; 
    } 
 
    public Object GUI_NO() throws Exception { 
        return rh.getField("g", instance); 
    }

    public Object GUI_NO(Object gui_no) throws Exception { 
        rh.setField("g", instance, gui_no); 
        return gui_no; 
    } 
 
    public Object GUI_OK() throws Exception { 
        return rh.getField("h", instance); 
    }

    public Object GUI_OK(Object gui_ok) throws Exception { 
        rh.setField("h", instance, gui_ok); 
        return gui_ok; 
    } 
 
    public Object GUI_PROCEED() throws Exception { 
        return rh.getField("i", instance); 
    }

    public Object GUI_PROCEED(Object gui_proceed) throws Exception { 
        rh.setField("i", instance, gui_proceed); 
        return gui_proceed; 
    } 
 
    public Object GUI_CONTINUE() throws Exception { 
        return rh.getField("j", instance); 
    }

    public Object GUI_CONTINUE(Object gui_continue) throws Exception { 
        rh.setField("j", instance, gui_continue); 
        return gui_continue; 
    } 
 
    public Object GUI_BACK() throws Exception { 
        return rh.getField("k", instance); 
    }

    public Object GUI_BACK(Object gui_back) throws Exception { 
        rh.setField("k", instance, gui_back); 
        return gui_back; 
    } 
 
    public Object GUI_TO_TITLE() throws Exception { 
        return rh.getField("l", instance); 
    }

    public Object GUI_TO_TITLE(Object gui_to_title) throws Exception { 
        rh.setField("l", instance, gui_to_title); 
        return gui_to_title; 
    } 
 
    public Object GUI_ACKNOWLEDGE() throws Exception { 
        return rh.getField("m", instance); 
    }

    public Object GUI_ACKNOWLEDGE(Object gui_acknowledge) throws Exception { 
        rh.setField("m", instance, gui_acknowledge); 
        return gui_acknowledge; 
    } 
 
    public Object GUI_OPEN_IN_BROWSER() throws Exception { 
        return rh.getField("n", instance); 
    }

    public Object GUI_OPEN_IN_BROWSER(Object gui_open_in_browser) throws Exception { 
        rh.setField("n", instance, gui_open_in_browser); 
        return gui_open_in_browser; 
    } 
 
    public Object GUI_COPY_LINK_TO_CLIPBOARD() throws Exception { 
        return rh.getField("o", instance); 
    }

    public Object GUI_COPY_LINK_TO_CLIPBOARD(Object gui_copy_link_to_clipboard) throws Exception { 
        rh.setField("o", instance, gui_copy_link_to_clipboard); 
        return gui_copy_link_to_clipboard; 
    } 
 
    public Object CONNECT_FAILED() throws Exception { 
        return rh.getField("p", instance); 
    }

    public Object CONNECT_FAILED(Object connect_failed) throws Exception { 
        rh.setField("p", instance, connect_failed); 
        return connect_failed; 
    } 
 
    public Object NEW_LINE() throws Exception { 
        return rh.getField("q", instance); 
    }

    public Object NEW_LINE(Object new_line) throws Exception { 
        rh.setField("q", instance, new_line); 
        return new_line; 
    } 
 
    public Object NARRATION_SEPARATOR() throws Exception { 
        return rh.getField("r", instance); 
    }

    public Object NARRATION_SEPARATOR(Object narration_separator) throws Exception { 
        rh.setField("r", instance, narration_separator); 
        return narration_separator; 
    } 
 
    public Object ELLIPSIS() throws Exception { 
        return rh.getField("s", instance); 
    }

    public Object ELLIPSIS(Object ellipsis) throws Exception { 
        rh.setField("s", instance, ellipsis); 
        return ellipsis; 
    } 
 
    public Object SPACE() throws Exception { 
        return rh.getField("t", instance); 
    }

    public Object SPACE(Object space) throws Exception { 
        rh.setField("t", instance, space); 
        return space; 
    } 
 

    /** 
     * @return Object
    **/ 
    public Object space() throws Exception { 
        Method method = clazz.getMethod("a"); 
        return rh.invokeReturn(method, instance); 
    } 

    /** 
     * @param a0
     * @return Object
    **/ 
    public Object days(long a0) throws Exception { 
        Method method = clazz.getMethod("a", long.class); 
        return rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @param a0
     * @return Object
    **/ 
    public Object hours(long a0) throws Exception { 
        Method method = clazz.getMethod("b", long.class); 
        return rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @param a0
     * @return Object
    **/ 
    public Object minutes(long a0) throws Exception { 
        Method method = clazz.getMethod("c", long.class); 
        return rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @param a0
     * @return Object
    **/ 
    public Object optionStatus(boolean a0) throws Exception { 
        Method method = clazz.getMethod("a", boolean.class); 
        return rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @param a0 net.minecraft.network.chat.Component
     * @param a1
     * @return Object
    **/ 
    public Object optionStatus(Object a0, boolean a1) throws Exception { 
        Method method = clazz.getMethod("a", ReflectionHelper.getClass("sw"), boolean.class); 
        return rh.invokeReturn(method, instance, a0, a1); 
    } 

    /** 
     * @param a0 net.minecraft.network.chat.Component
     * @param a1 net.minecraft.network.chat.Component
     * @return Object
    **/ 
    public Object optionNameValue(Object a0, Object a1) throws Exception { 
        Method method = clazz.getMethod("a", ReflectionHelper.getClass("sw"), ReflectionHelper.getClass("sw")); 
        return rh.invokeReturn(method, instance, a0, a1); 
    } 

    /** 
     * @param a0 net.minecraft.network.chat.Component[]
     * @return Object
    **/ 
    public Object joinForNarration(Object a0) throws Exception { 
        Method method = clazz.getMethod("a", ReflectionHelper.getClass("sw")); 
        return rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @param a0 net.minecraft.network.chat.Component[]
     * @return Object
    **/ 
    public Object joinLines(Object a0) throws Exception { 
        Method method = clazz.getMethod("b", ReflectionHelper.getClass("sw")); 
        return rh.invokeReturn(method, instance, a0); 
    } 

    /** 
     * @param a0 java.util.Collection
     * @return Object
    **/ 
    public Object joinLines(Object a0) throws Exception { 
        Method method = clazz.getMethod("a", java.util.Collection.class); 
        return rh.invokeReturn(method, instance, a0); 
    } 
} 
