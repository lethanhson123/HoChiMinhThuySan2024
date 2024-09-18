import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { environment } from 'src/environments/environment';
import { ToChuc } from 'src/app/shared/ToChuc.model';
import { ToChucService } from 'src/app/shared/ToChuc.service';
import { ToChucHoNuoiDetailComponent } from '../to-chuc-ho-nuoi-detail/to-chuc-ho-nuoi-detail.component';
import { ToChucPhuongTienKhaiThacDetailComponent } from '../to-chuc-phuong-tien-khai-thac-detail/to-chuc-phuong-tien-khai-thac-detail.component';
import { ToChucTramQuanTracDetailComponent } from '../to-chuc-tram-quan-trac-detail/to-chuc-tram-quan-trac-detail.component';
import { ToChucHopTacXaDetailComponent } from '../to-chuc-hop-tac-xa-detail/to-chuc-hop-tac-xa-detail.component';
import { ToChucGiongDetailComponent } from '../to-chuc-giong-detail/to-chuc-giong-detail.component';
import { ToChucCuaHangDetailComponent } from '../to-chuc-cua-hang-detail/to-chuc-cua-hang-detail.component';

@Component({
  selector: 'app-to-chuc-info',
  templateUrl: './to-chuc-info.component.html',
  styleUrls: ['./to-chuc-info.component.css']
})
export class ToChucInfoComponent implements OnInit {

  constructor(
    private dialog: MatDialog,
    public router: Router,
    private activeRouter: ActivatedRoute,
    public ToChucService: ToChucService,
  ) {
    this.ToChucService.IsShowLoading = true;
    this.ToChucService.BaseParameter.ID = Number(this.activeRouter.snapshot.params.ID);
    this.ToChucService.FormData.ID = this.ToChucService.BaseParameter.ID;

    this.ToChucService.GetByIDAsync().subscribe(
      res => {
        this.ToChucService.FormData = res as ToChuc;

        if (this.ToChucService.FormData.ParentID == 1) {
          const dialogConfig = new MatDialogConfig();
          dialogConfig.disableClose = true;
          dialogConfig.autoFocus = true;
          dialogConfig.width = environment.DialogConfigWidth;
          dialogConfig.data = { ID: this.ToChucService.FormData.ID };
          const dialog = this.dialog.open(ToChucHoNuoiDetailComponent, dialogConfig);
          dialog.afterClosed().subscribe(() => {
            window.self.close();
          });
        }
        if (this.ToChucService.FormData.ParentID == 7) {
          const dialogConfig = new MatDialogConfig();
          dialogConfig.disableClose = true;
          dialogConfig.autoFocus = true;
          dialogConfig.width = environment.DialogConfigWidth;
          dialogConfig.data = { ID: this.ToChucService.FormData.ID };
          const dialog = this.dialog.open(ToChucTramQuanTracDetailComponent, dialogConfig);
          dialog.afterClosed().subscribe(() => {
            window.self.close();
          });
        }
        if (this.ToChucService.FormData.ParentID == 8) {
          const dialogConfig = new MatDialogConfig();
          dialogConfig.disableClose = true;
          dialogConfig.autoFocus = true;
          dialogConfig.width = environment.DialogConfigWidth;
          dialogConfig.data = { ID: this.ToChucService.FormData.ID };
          const dialog = this.dialog.open(ToChucHopTacXaDetailComponent, dialogConfig);
          dialog.afterClosed().subscribe(() => {
            window.self.close();
          });
        }
        if (this.ToChucService.FormData.ParentID == 9) {
          const dialogConfig = new MatDialogConfig();
          dialogConfig.disableClose = true;
          dialogConfig.autoFocus = true;
          dialogConfig.width = environment.DialogConfigWidth;
          dialogConfig.data = { ID: this.ToChucService.FormData.ID };
          const dialog = this.dialog.open(ToChucPhuongTienKhaiThacDetailComponent, dialogConfig);
          dialog.afterClosed().subscribe(() => {
            window.self.close();
          });
        }
        if (this.ToChucService.FormData.ParentID == 10) {
          const dialogConfig = new MatDialogConfig();
          dialogConfig.disableClose = true;
          dialogConfig.autoFocus = true;
          dialogConfig.width = environment.DialogConfigWidth;
          dialogConfig.data = { ID: this.ToChucService.FormData.ID };
          const dialog = this.dialog.open(ToChucGiongDetailComponent, dialogConfig);
          dialog.afterClosed().subscribe(() => {
            window.self.close();
          });
        }
        if (this.ToChucService.FormData.ParentID == 12) {
          const dialogConfig = new MatDialogConfig();
          dialogConfig.disableClose = true;
          dialogConfig.autoFocus = true;
          dialogConfig.width = environment.DialogConfigWidth;
          dialogConfig.data = { ID: this.ToChucService.FormData.ID };
          const dialog = this.dialog.open(ToChucCuaHangDetailComponent, dialogConfig);
          dialog.afterClosed().subscribe(() => {
            window.self.close();
          });
        }
        
      },
      err => {
      },
      ()=>{
        this.ToChucService.IsShowLoading = false;
      }
    );
  }

  ngOnInit(): void {
  }

}
