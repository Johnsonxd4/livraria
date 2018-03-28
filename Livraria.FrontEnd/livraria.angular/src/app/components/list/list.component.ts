import { Component, OnInit } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/map';
import { element } from 'protractor';
import {ActivatedRoute} from "@angular/router";
import { Router } from '@angular/router';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  title = 'listar livros';
  private apiUrl = 'http://localhost:62847/api/livros/';
  data: any = [];

  constructor(private http: Http, private router: Router) { 
    this.Consultar();
  }

  getLivros(){
    return this.http.get(this.apiUrl)
    .map((res: Response) => res.json())
  }
  Consultar(){
    this.getLivros()
    .subscribe(data => {
      console.log(data);
      this.data = data
    });
  }
  onClickItem($event, codigo){
    if(confirm(`Deseja realmente apagar o livro ${this.data.filter((element) => element.codigo == codigo)[0].titulo}`)){
        this
        .http
        .delete(`${this.apiUrl}${codigo}`)
        .subscribe(
          data => {
            alert("Registro apagado com sucesso!");
            this.Consultar();
          },
          error => {
              alert("Erro ao apagar o registro");
          }
        )
    }
  }

  onEditarItem($event, codigo, titulo){
    this.router.navigate(['/update', codigo,titulo]);
  }

  ngOnInit() {
  }

}
