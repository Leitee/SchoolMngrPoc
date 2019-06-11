import { NgModule } from '@angular/core';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule, 
    MatButtonModule, 
    MatSidenavModule, 
    MatIconModule, 
    MatListModule, 
    MatMenuModule, 
    MatGridListModule, 
    MatCardModule, 
    MatExpansionModule, 
    MatFormFieldModule, 
    MatInputModule,
    MatCheckboxModule,
    MatDialogModule,
    MatProgressSpinnerModule,
    MatButtonToggleModule,
    MatAutocompleteModule,
    MatStepperModule
} from '@angular/material';

@NgModule({
    imports: [
        LayoutModule,
        MatToolbarModule,
        MatButtonModule,
        MatSidenavModule,
        MatIconModule,
        MatListModule,
        MatMenuModule,
        MatGridListModule,
        MatCardModule,
        MatExpansionModule,
        MatFormFieldModule,
        MatInputModule,
        MatCheckboxModule,
        MatDialogModule,
        MatProgressSpinnerModule,
        MatButtonToggleModule,
        MatAutocompleteModule,
        MatStepperModule
    ],
    exports: [
        LayoutModule,
        MatToolbarModule,
        MatButtonModule,
        MatSidenavModule,
        MatIconModule,
        MatListModule,
        MatMenuModule,
        MatGridListModule,
        MatCardModule,
        MatExpansionModule,
        MatFormFieldModule,
        MatInputModule,
        MatCheckboxModule,
        MatDialogModule,
        MatProgressSpinnerModule,
        MatButtonToggleModule,
        MatAutocompleteModule,
        MatStepperModule
    ]
})
export class MaterialModule { }