import * as tslib_1 from "tslib";
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MainNavComponent } from './main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule, MatButtonModule, MatSidenavModule, MatIconModule, MatListModule, MatGridListModule, MatCardModule, MatMenuModule, MatTableModule, MatPaginatorModule, MatSortModule } from '@angular/material';
import { CardRenderComponent } from './card-render/card-render.component';
import { HttpClientModule } from '@angular/common/http';
import { StudentsTableComponent } from './students-table/students-table.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatFormFieldModule } from '@angular/material/form-field';
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = tslib_1.__decorate([
        NgModule({
            declarations: [
                AppComponent,
                MainNavComponent,
                CardRenderComponent,
                StudentsTableComponent,
            ],
            imports: [
                MatFormFieldModule,
                FlexLayoutModule,
                BrowserModule,
                AppRoutingModule,
                BrowserAnimationsModule,
                LayoutModule,
                MatToolbarModule,
                MatButtonModule,
                MatSidenavModule,
                MatIconModule,
                MatListModule,
                MatGridListModule,
                MatCardModule,
                MatMenuModule,
                HttpClientModule,
                MatTableModule,
                MatPaginatorModule,
                MatSortModule
            ],
            providers: [],
            bootstrap: [AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=app.module.js.map