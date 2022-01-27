package ec.com.aekmot.dao;

import ec.com.aekmot.model.Persona;
import java.sql.PreparedStatement;

/**
 *
 * @author aekmot
 */
public class PersonaDao extends DAO {

    public void registrar(Persona persona) throws Exception {
        try {
            this.Conectar();
            PreparedStatement st = this.getCn().prepareStatement("INSERT INTO Persona (nombre, sexo) values(?,?)");
            st.setString(1, persona.getNombre());
            st.setString(2, persona.getSexo());
            st.executeUpdate();
        } catch (Exception e) {
            throw e;
        } finally {
            this.Cerrar();
        }
    }

}
