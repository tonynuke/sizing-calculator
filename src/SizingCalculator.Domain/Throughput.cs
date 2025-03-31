using SizingCalculator.Domain.Persistence;

namespace SizingCalculator.Domain;

// https://www.confluent.io/blog/kafka-fastest-messaging-system/
public class Throughput
{
    public required long Value { get; set; }

    public static Throughput Kafka => new Throughput { Value = 5 * Adviser.Megabyte };
    public static Throughput RabbitMq => new Throughput { Value = 1 * Adviser.Megabyte };
}
