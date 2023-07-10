const express = require("express");
const cors = require('cors');
const { Pool } = require('pg');
const app = express();
const port = 8081;

app.use(express.json());

// Permitir solicitudes de cualquier origen
app.use(cors());

// Configura la conexión a la base de datos PostgreSQL
const pool = new Pool({
    user: 'postgres',
    host: 'localhost',
    database: 'db_sga',
    password: '1234567',
    port: 5432,
  });

// Obtener todos los elementos
app.get('/api/students', (req, res) => {
    pool.query('SELECT * FROM personal', (error, results) => {
      if (error) {
        console.log(error);
      }
      res.json(results.rows);
    });
});

// Crear un nuevo estudiante
app.post('/api/students', (req, res) => {
    const { cedula, apellido1, apellido2, nombres, genero } = req.body;
    pool.query(
      'INSERT INTO personal (cedula, apellido1, apellido2, nombres, genero) VALUES ($1, $2, $3, $4, $5) RETURNING *',
      [cedula, apellido1, apellido2, nombres, genero],
      (error, results) => {
        if (error) {
            console.log(error);
        }
        res.send('estudiante creado correctamente');
      }
    );
  });

// Actualizar un estudiante existente
app.put('/api/students/:id', (req, res) => {
    const id = parseInt(req.params.id);
    const { cedula, apellido1, apellido2, nombres, genero } = req.body;
    pool.query(
      'UPDATE personal SET cedula = $1, apellido1 = $2, apellido2 = $3, nombres = $4, genero = $5 WHERE id = $6',
      [cedula, apellido1, apellido2, nombres, genero, id],
      (error, results) => {
        if (error) {
            console.log(error);
        }
        res.send('estudiante actualizado correctamente');
      }
    );
  });

// Eliminar un estudiantes existente
app.delete('/api/students/:idpersonal', (req, res) => {
    const id = parseInt(req.params.idpersonal);
    pool.query('DELETE FROM personal WHERE id = $1', [id], (error, results) => {
      if (error) {
        console.log(error);
      }
      res.send('estudiante eliminado correctamente');
    });
  });

app.listen(port, () => {
    console.log(`Servidor en ejecución en http://localhost:${port}`);
  });