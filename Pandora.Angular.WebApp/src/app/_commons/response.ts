export class ApiResponse<T>
{
	public data: T;
	public errors: string[];
	public hasError: boolean;
	public errorsCount: number;
	public responseCode: number;	

	constructor() {
		this.errors = new Array<string>();
	}
}