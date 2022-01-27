package ec.com.aekmot.bean;

import ec.com.aekmot.dao.PersonaDao;
import ec.com.aekmot.model.Persona;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.RequestScoped;

/**
 *
 * @author aekmot
 */
@ManagedBean
@RequestScoped
public class PersonaBean {

    private Persona persona = new Persona();

    public Persona getPersona() {
        return persona;
    }

    public void setPersona(Persona persona) {
        this.persona = persona;
    }

    public void registrar() throws Exception {
        PersonaDao dao;
        try {
            dao = new PersonaDao();
            dao.registrar(persona);
        } catch (Exception e) {
            throw e;
        }
    }

}
