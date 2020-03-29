import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-no-registers-found',
  templateUrl: './no-registers-found.component.html',
  styleUrls: ['./no-registers-found.component.css']
})
export class NoRegistersFoundComponent implements OnInit {

  constructor(private router: Router) { }

  @Input() texto: string;
  @Input() rota: string;

  ngOnInit(): void {
  }

  navegarRota(): void {
    this.router.navigateByUrl(this.rota);
  }

}
