import { PromocionService } from 'src/app/services/promocion.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-canje',
  templateUrl: './canje.component.html',
  styles: [
  ]
})
export class CanjeComponent implements OnInit {

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
      codigo: ['', Validators.required],
    });
  }

  Guardar() {
    this.service.guardarCanjeCodigo(this.miFormulario.value)
      .subscribe(data => {

        if (data >0) {
          Swal.fire(
            'Mensaje!',
            'Se canjeo correctamente el codigo !!',
            'error'
          );
        } else {
          Swal.fire(
            'Mensaje!',
            'El codigo ya ha sido canjeado anteriormente!!',
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
