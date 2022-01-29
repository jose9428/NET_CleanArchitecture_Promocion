import { PromocionService } from 'src/app/services/promocion.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-generar',
  templateUrl: './generar.component.html',
  styles: [
  ]
})
export class GenerarComponent implements OnInit {
  miFormulario: FormGroup;
  valor: number;

  constructor(private service: PromocionService,
              private formBuilder: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.CrearFormulario();
  }

  CrearFormulario() {
    this.miFormulario = this.formBuilder.group({
      email: ['', Validators.required],
      nombre: ['', Validators.required]
    });
  }

  Guardar() {

    this.service.guardarGeneracionCodigo(this.miFormulario.value)
      .subscribe(data => {

        if (data >0) {
          Swal.fire(
            'Mensaje!',
            'El codigo se genero satisfactorianente !!',
            'error'
          );
        } else {
          Swal.fire(
            'Mensaje!',
            'El codigo ya no se encuentra disponible',
            'success'
          );
        }
      },
        error => {
          console.log(error);
          Swal.fire(
            'Mensaje!',
            'Ha ocurrido un error interno!!',
            'error'
          );
        }
      );

  }

}
