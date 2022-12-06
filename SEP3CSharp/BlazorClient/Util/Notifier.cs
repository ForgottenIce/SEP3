using Radzen;

namespace BlazorClient.Util; 

public static class Notifier {
	public static void NotifySuccess(NotificationService service, string? summery, string? description, double? duration) {
		NotificationMessage message = new NotificationMessage {
			Severity = NotificationSeverity.Success,
			Summary = summery ?? "Success",
			Detail = description ?? "",
			Duration = duration
		};
		
		service.Notify(message);
	}

	public static void NotifyInfo(NotificationService service, string? summery, string? description, double? duration) {
		NotificationMessage message = new NotificationMessage {
			Severity = NotificationSeverity.Info,
			Summary = summery ?? "Info",
			Detail = description ?? "",
			Duration = duration
		};
		
		service.Notify(message);
	}

	public static void NotifyError(NotificationService service, string? summery, string? description, double? duration) {
		NotificationMessage message = new NotificationMessage {
			Severity = NotificationSeverity.Error,
			Summary = summery ?? "Error",
			Detail = description ?? "",
			Duration = duration
		};
		
		service.Notify(message);
	}

	public static void NotifyWarning(NotificationService service, string? summery, string? description, double? duration) {
		NotificationMessage message = new NotificationMessage {
			Severity = NotificationSeverity.Warning,
			Summary = summery ?? "Warning",
			Detail = description ?? "",
			Duration = duration
		};
		
		service.Notify(message);
	}
}